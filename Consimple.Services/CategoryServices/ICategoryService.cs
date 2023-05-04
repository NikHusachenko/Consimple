using Consimple.Database.Entities;
using Consimple.Services.CategoryServices.Models;
using Consimple.Services.Response;

namespace Consimple.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<ResponseService<long>> Create(CreateCategoryHttpPostViewModel vm);

        Task<ResponseService<CategoryEntity>> GetById(long id);
        Task<ResponseService<CategoryEntity>> GetByName(string name);
        Task<ICollection<CategoryEntity>> GetAll();
        Task<ICollection<CategoryEntity>> GetDemandedCategories(long clientId);

        Task<ResponseService> Update(CategoryEntity entity);
    }
}