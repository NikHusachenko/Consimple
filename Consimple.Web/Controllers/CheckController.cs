using Consimple.Services.CheckServices;
using Microsoft.AspNetCore.Mvc;

namespace Consimple.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly ICheckService _checkService;

        public CheckController(ICheckService checkService)
        {
            _checkService = checkService;
        }
    }
}