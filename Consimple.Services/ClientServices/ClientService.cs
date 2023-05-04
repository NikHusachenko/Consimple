using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.Database.Enums;
using Consimple.EntityFramework.Repository;
using Consimple.Services.ClientServices.Models;
using Consimple.Services.Response;
using Microsoft.Extensions.Logging;

namespace Consimple.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<ClientEntity> _clientRepository;
        private readonly ILogger<IClientService> _logger;

        public ClientService(IGenericRepository<ClientEntity> clientRepository,
            ILogger<IClientService> logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public async Task<ResponseService> CheckClientExists(string firstName, string lastName, string middleName)
        {
            ClientEntity dbRecord = await _clientRepository
                .GetBy(client => client.FirstName == firstName &&
                client.LastName == lastName &&
                client.MiddleName == middleName);

            if (dbRecord != null)
            {
                return ResponseService.Error(Errors.WAS_CREATED);
            }
            return ResponseService.Ok();
        }

        public async Task<ResponseService<long>> Create(CreateClientHttpPostViewModel vm)
        {
            var checkResult = await CheckClientExists(vm.FirstName, vm.LastName, vm.MiddleName);
            if (checkResult.IsError)
            {
                return ResponseService<long>.Error(checkResult.ErrorMessage);
            }

            ClientEntity dbRecord = new ClientEntity()
            {
                BirthDate = vm.BirthDate,
                CreatedOn = DateTime.Now,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                MiddleName = vm.MiddleName,
                Type = UserType.User,
            };

            try
            {
                await _clientRepository.Create(dbRecord);
                return ResponseService<long>.Ok(dbRecord.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ClientService -> Create exception: {ex.Message}");
                return ResponseService<long>.Error(ex.Message);
            }
        }
    }
}