using Consimple.Database.Entities;
using Consimple.Services.ProductServices.Models;
using Consimple.Services.Response;

namespace Consimple.Services.ProductServices
{
    public interface IProductService
    {
        Task<ResponseService<long>> Create(CreateProductHttpPostViewModel vm);
        Task<ResponseService> Update(ProductEntity entity);
    }
}