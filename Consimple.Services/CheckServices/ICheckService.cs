using Consimple.Database.Entities;
using Consimple.Services.Response;

namespace Consimple.Services.CheckServices
{
    public interface ICheckService
    {
        Task<ResponseService<long>> OpenCheck(long clientId, ICollection<ProductEntity> products);
        Task<ResponseService<long>> CloseCheck(long id);

        Task<ResponseService<CheckEntity>> GetById(long id);
        Task<CheckEntity> GetLast();
        Task<ICollection<CheckEntity>> GetAll();
        Task<ICollection<CheckEntity>> GetByDate(DateTime date, bool? isClosed);
        Task<ICollection<CheckEntity>> GetByPeriod(DateTime from, DateTime to, bool? isClosed);
        Task<ICollection<CheckEntity>> GetFromDate(DateTime date, bool? isClosed);
    }
}