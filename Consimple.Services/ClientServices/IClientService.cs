using Consimple.Services.ClientServices.Models;
using Consimple.Services.Response;

namespace Consimple.Services.ClientServices
{
    public interface IClientService
    {
        Task<ResponseService> CheckClientExists(string fistName, string lastName, string middleName);

        Task<ResponseService<long>> Create(CreateClientHttpPostViewModel vm);
    }
}