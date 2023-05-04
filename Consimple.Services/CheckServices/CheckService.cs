using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.EntityFramework.Repository;
using Consimple.Services.ProductServices;
using Consimple.Services.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Consimple.Services.CheckServices
{
    public class CheckService : ICheckService
    {
        private readonly IGenericRepository<CheckEntity> _checkRepository;
        private readonly IProductService _productService;
        private readonly ILogger<CheckService> _logger;

        public CheckService(IGenericRepository<CheckEntity> checkRepository,
            IProductService productService,
            ILogger<CheckService> logger)
        {
            _checkRepository = checkRepository;
            _productService = productService;
            _logger = logger;
        }

        public async Task<ResponseService<long>> CloseCheck(long id)
        {
            CheckEntity dbRecord = await _checkRepository.GetById(id);
            if (dbRecord == null)
            {
                return ResponseService<long>.Error(Errors.NOT_FOUND_ERROR);
            }

            dbRecord.IsClosed = true;
            dbRecord.ClosedOn = DateTime.Now;
            
            try
            {
                await _checkRepository.Update(dbRecord);
                return ResponseService<long>.Ok(dbRecord.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CheckService -> CloseCheck exception: {ex.Message}");
                return ResponseService<long>.Error(ex.Message);
            }
        }

        public async Task<ICollection<CheckEntity>> GetAll()
        {
            return await _checkRepository.GetAll()
                .Where(check => !check.IsClosed)
                .ToListAsync();
        }

        public async Task<ICollection<CheckEntity>> GetByDate(DateTime date, bool? isClosed)
        {
            IQueryable<CheckEntity> query = _checkRepository.GetAll()
                .Where(check => check.OpenedOn == date);

            if (isClosed != null)
            {
                query = query.Where(check => check.IsClosed == isClosed.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<ResponseService<CheckEntity>> GetById(long id)
        {
            CheckEntity dbRecord = await _checkRepository.GetById(id);
            if (dbRecord == null)
            {
                return ResponseService<CheckEntity>.Error(Errors.NOT_FOUND_ERROR);
            }
            return ResponseService<CheckEntity>.Ok(dbRecord);
        }

        public async Task<ICollection<CheckEntity>> GetByPeriod(DateTime from, DateTime to, bool? isClosed)
        {
             IQueryable<CheckEntity> query = _checkRepository.GetAll()
                .Where(check => check.OpenedOn >= from &&
                    check.OpenedOn <= to);

            if (isClosed != null)
            {
                query = query.Where(check => check.IsClosed == isClosed.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<ICollection<CheckEntity>> GetFromDate(DateTime date, bool? isClosed)
        {
            IQueryable<CheckEntity> query = _checkRepository.GetAll()
                .Where(check => check.OpenedOn >= date)
                .Include(check => check.Client);

            if (isClosed != null)
            {
                query = query.Where(check => check.IsClosed == isClosed.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<CheckEntity> GetLast()
        {
            return await _checkRepository.GetAll().LastAsync();
        }

        public async Task<ResponseService<long>> OpenCheck(long clientId, ICollection<ProductEntity> products)
        {
            CheckEntity dbRecord = new CheckEntity()
            {
                ClientFK = clientId,
                IsClosed = false,
                OpenedOn = DateTime.Now,
            };

            await _checkRepository.Create(dbRecord);

            foreach (ProductEntity product in products)
            {
                product.CheckFK = dbRecord.Id;
                var response = await _productService.Update(product);
                if (response.IsError)
                {
                    return ResponseService<long>.Error(response.ErrorMessage);
                }
            }

            return ResponseService<long>.Ok(dbRecord.Id);
        }
    }
}