using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.Services.ClientServices;
using Consimple.Services.ClientServices.Models;
using Consimple.Web.Models.Client;
using Microsoft.AspNetCore.Mvc;

namespace Consimple.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
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
        public async Task<ICollection<BirthdayHttpGetViewModel>> GetBirthday(DateTime birthDate)
        {
            var clients = await _clientService.GetBirthday(birthDate);
            List<BirthdayHttpGetViewModel> model = new List<BirthdayHttpGetViewModel>();
            model.AddRange(clients.Select(client => new BirthdayHttpGetViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName
            }));

            return model;
        }
    }
}