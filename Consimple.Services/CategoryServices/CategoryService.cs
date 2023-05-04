using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.EntityFramework.Repository;
using Consimple.Services.CategoryServices.Models;
using Consimple.Services.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Consimple.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        private readonly IGenericRepository<ProductCategoryEntity> _productCategoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IGenericRepository<CategoryEntity> categoryRepository,
            IGenericRepository<ProductCategoryEntity> productCategoryRepository,
            ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }

        public async Task<ResponseService<long>> Create(CreateCategoryHttpPostViewModel vm)
        {
            CategoryEntity dbRecord = await _categoryRepository.GetBy(category => category.Name == vm.Name);
            if (dbRecord == null)
            {
                return ResponseService<long>.Error(Errors.WAS_CREATED_ERROR);
            }

            dbRecord = new CategoryEntity()
            {
                Name = vm.Name,
            };

            try
            {
                await _categoryRepository.Create(dbRecord);
                return ResponseService<long>.Ok(dbRecord.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CategoryService -> Create exception: {ex.Message}");
                return ResponseService<long>.Error(ex.Message);
            }
        }

        public async Task<ICollection<CategoryEntity>> GetAll()
        {
            return await _categoryRepository.GetAll()
                .ToListAsync();
        }

        public async Task<ResponseService<CategoryEntity>> GetById(long id)
        {
            CategoryEntity dbRecord = await _categoryRepository.GetById(id);
            if (dbRecord == null)
            {
                return ResponseService<CategoryEntity>.Error(Errors.NOT_FOUND_ERROR);
            }
            return ResponseService<CategoryEntity>.Ok(dbRecord);
        }

        public async Task<ResponseService<CategoryEntity>> GetByName(string name)
        {
            CategoryEntity dbRecord = await _categoryRepository.GetBy(category => category.Name == name);
            if (dbRecord == null)
            {
                return ResponseService<CategoryEntity>.Error(Errors.NOT_FOUND_ERROR);
            }
            return ResponseService<CategoryEntity>.Ok(dbRecord);
        }

        public async Task<ICollection<CategoryEntity>> GetDemandedCategories(long clientId)
        {
            return await _categoryRepository.GetAll()
                .Include(category => category.Products)
                    .ThenInclude(pc => pc.Product)
                .Where(category => category.Products
                    .Where(product => !product.Product.DeletedOn.HasValue &&
                        product.Product.Check.IsClosed &&
                        product.Product.Check.Client.Id == clientId).Count() > 0)
                .ToListAsync();
        }

        public async Task<ResponseService> Update(CategoryEntity entity)
        {
            try
            {
                await _categoryRepository.Update(entity);
                return ResponseService.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"CategoryService -> Update exception: {ex.Message}");
                return ResponseService.Error(ex.Message);
            }
        }


    }
}