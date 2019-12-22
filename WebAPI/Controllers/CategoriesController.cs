using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VIEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.Get();

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.Get(id);

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] CategoryToCreateDTO categoryToCreate)
        {
            var category = _categoryService.Post(categoryToCreate);

            return CreatedAtRoute("GetCategory", new { Id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryToCreateDTO categoryToCreate)
        {
            if (_categoryService.Put(categoryToCreate, id))
            {
                return NoContent();
            }
            return BadRequest("Fail to update Product");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _categoryService.Delete(id))
            {
                return NoContent();
            }
            return BadRequest("Fail to delete Product");
        }
    }
}
