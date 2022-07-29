using Microsoft.AspNetCore.Mvc;
using RestfullAPI.Repositories;
namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository CategoryRepository;
        public CategoryController(ICategoryRepository CategoryRepository)
        {
            this.CategoryRepository = CategoryRepository;
        }
        // Get all categories with list of products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(CategoryRepository.GetAll());
        }
        // Get Category by id with list of products
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            return Ok(CategoryRepository.GetById(id));
        }
    }
}
