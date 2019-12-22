using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VIEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.Get();

            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.Get(id);

            if (product == null)
            {
                return BadRequest("Product doesn't exist");
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductToCreateDTO productToCreate)
        {
            var product = _productService.Post(productToCreate);

            return CreatedAtRoute("GetProduct", new { Id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductToCreateDTO productToCreate)
        {
            if (_productService.Put(productToCreate, id))
            {
                return NoContent();
            }
            return BadRequest("Fail to update Product");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productService.Delete(id))
            {
                return NoContent();
            }
            return BadRequest("Fail to delete Product");
        }
    }
}