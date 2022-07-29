using Microsoft.AspNetCore.Mvc;
using RestfullAPI.Models;
using RestfullAPI.Repositories;
namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository ProductRepo;
        // Inject Product Repo
        public ProductController(IProductRepository ProductRepo)
        {
            this.ProductRepo = ProductRepo;
        }
        // Get verb to get all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductRepo.GetAll());
        }
        // Get verb to get all products with category
        [HttpGet("Category")]
        public IActionResult GetProductsWithCategory()
        {
            return Ok(ProductRepo.GetAllWithCategory());
        }
        // Get verb + id to get product by id
        [HttpGet("id/{id:int}", Name = "ProductRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(ProductRepo.GetById(id));
        }
        // Get Verb + name to get product by name
        [HttpGet("name/{name:regex(.*)}")]
        public IActionResult GetByName(string name)
        {
            return Ok(ProductRepo.GetByName(name));
        }
        // Post verb to add product
        [HttpPost]
        public IActionResult InsertProduct(Product NewProduct)
        {
            if (ModelState.IsValid)
            {
                ProductRepo.Insert(NewProduct);
                // Return url of created product in the response body
                string url = Url.Link("ProductRoute", new { id = NewProduct.Id });
                return Created(url, NewProduct);
            }
            return BadRequest(ModelState);
        }
        // Put verb to update product
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product UpdatedProduct)
        {
            if (ModelState.IsValid)
            {
                ProductRepo.Update(id, UpdatedProduct);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return BadRequest(ModelState);
        }
        // Delete verb to delete product through try and catch
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            try
            {
                ProductRepo.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
