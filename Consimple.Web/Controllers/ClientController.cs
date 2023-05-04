using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.Services.ClientServices;
using Consimple.Services.ClientServices.Models;
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
        [Route("Create")]
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

        [HttpGet("All")]
        public async Task<ICollection<ClientEntity>> GetAll()
        {
            ICollection<ClientEntity> clients = await _clientService.GetAll();
            return clients;
        }
    }
}