using Api_dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using webapi;
using webapi.Models;

namespace Api_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService service)
        {
            this.categoryService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Category> GetAllCategories()
        {
            return categoryService.GetAllCategories();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAlgo()
        {
            return Ok("Algo bien.");
        }

        [HttpGet("{id}")]
        [Route("[action]")]
        public Category? GetById(Guid id)
        {
            return categoryService.GetCategory(id);
        }

    }
}
