using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.Services.CheckServices;
using Consimple.Services.ClientServices;
using Consimple.Services.ClientServices.Models;
using Consimple.Web.Models.Client;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Consimple.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ICheckService _checkService;

        public ClientController(IClientService clientService,
            ICheckService checkService)
        {
            _clientService = clientService;
            _checkService = checkService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]CreateClientHttpPostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _clientService.Create(vm);
            if (response.IsError)
            {
                return BadRequest(new { message = response.ErrorMessage });
            }

            return Ok(new { success = true, message = Messages.CREATED_SUCCESSFULY });
        }

        [HttpGet]
        [Route("all")]
        public async Task<ICollection<ClientEntity>> GetAll()
        {
            ICollection<ClientEntity> clients = await _clientService.GetAll();
            return clients;
        }

        [HttpGet]
        [Route("Birthday")]
        public async Task<ICollection<ClientDefaultHttpGetViewModel>> GetBirthday(DateTime birthDate)
        {
            var clients = await _clientService.GetBirthday(birthDate);
            List<ClientDefaultHttpGetViewModel> model = new List<ClientDefaultHttpGetViewModel>();
            model.AddRange(clients.Select(client => new ClientDefaultHttpGetViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName
            }));

            return model;
        }

        [HttpGet]
        [Route("last")]
        public async Task<ICollection<ClientDefaultHttpGetViewModel>> GetLastBuyers(DateTime from, bool? isClosed)
        {
            ICollection<CheckEntity> checks = await _checkService.GetFromDate(from, isClosed);
            List<ClientDefaultHttpGetViewModel> vm = new List<ClientDefaultHttpGetViewModel>();
            vm.AddRange(checks.Select(check => new ClientDefaultHttpGetViewModel()
            {
                FirstName = check.Client.FirstName,
                LastName = check.Client.LastName,
                Id = check.Client.Id,
                MiddleName = check.Client.MiddleName,
            }));
            return vm;
        }
    }
}