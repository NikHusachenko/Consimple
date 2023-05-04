using Microsoft.AspNetCore.Mvc;

namespace Consimple.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Index")]
        public ActionResult<string> Index()
        {
            return "Hello, World!";
        }
    }
}