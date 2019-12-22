using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VIEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerservice)
        {
            _providerService = providerservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var providers = await _providerService.Get();
            if (providers == null)
            {
                return NoContent();
            }

            return Ok(providers);
        }

        [HttpGet("{id}", Name = "GetProviders")]
        public async Task<IActionResult> Get(int id)
        {
            var provider = await _providerService.Get(id);
            if (provider == null)
            {
                return NoContent();
            }

            return Ok(provider);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProviderToCreateDTO providerToCreate)
        {
            var provider = _providerService.Post(providerToCreate);

            return CreatedAtRoute("GetProviders", new { Id = provider.ProviderId }, provider);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProviderToCreateDTO providerToCreate)
        {
            if (_providerService.Put(providerToCreate, id))
            {
                return NoContent();
            }
            return BadRequest("Fail to update Provider");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _providerService.Delete(id))
            {
                return NoContent();
            }
            return BadRequest("Fail to delete Provider");
        }
    }
}
