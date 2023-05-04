using Consimple.Common;
using Consimple.Database.Entities;
using Consimple.Services.CategoryServices;
using Consimple.Services.CategoryServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consimple.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ICollection<CategoryEntity>> GetAll()
        {
            return await _categoryService.GetAll();
        }

        [HttpPost]
        [Route("create")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([FromBody]CreateCategoryHttpPostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.Create(vm);
            if (response.IsError)
            {
                return BadRequest(new { message = response.ErrorMessage });
            }

            return Ok(new { success = true, message = Messages.CREATED_SUCCESSFULY });
        }
    }
}