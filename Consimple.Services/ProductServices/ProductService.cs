using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.EntityFramework.Repository;
using Consimple.Services.CategoryServices;
using Consimple.Services.ProductServices.Models;
using Consimple.Services.Response;
using Microsoft.Extensions.Logging;

namespace Consimple.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<ProductEntity> _productRepository;
        private readonly IGenericRepository<ProductCategoryEntity> _productCategoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IGenericRepository<ProductEntity> productRepository,
            IGenericRepository<ProductCategoryEntity> productCategoryRepository,
            ICategoryService categoryService,
            ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<ResponseService<long>> Create(CreateProductHttpPostViewModel vm)
        {
            ProductEntity dbRecord = await _productRepository.GetBy(product => product.Name == vm.Name);
            if (dbRecord != null)
            {
                return ResponseService<long>.Error(Errors.WAS_CREATED_ERROR);
            }

            dbRecord = new ProductEntity()
            {
                Count = vm.Count,
                Name = vm.Name,
                CreatedOn = DateTime.Now,
            };

            await _productRepository.Create(dbRecord);

            foreach (string categoryName in vm.Categories)
            {
                var response = await _categoryService.GetByName(categoryName);
                if (response.IsError)
                {
                    return ResponseService<long>.Error(response.ErrorMessage);
                }

                await _productCategoryRepository.Create(new ProductCategoryEntity()
                {
                    CategoryFK = response.Value.Id,
                    ProductFK = dbRecord.Id,
                });
            }

            return ResponseService<long>.Ok(dbRecord.Id);
        }

        public async Task<ResponseService> Update(ProductEntity entity)
        {
            try
            {
                await _productRepository.Update(entity);
                return ResponseService.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductService -> Update exception: {ex.Message}");
                return ResponseService.Error(ex.Message);
            }
        }
    }
}