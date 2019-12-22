using System;
using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<OrderToReturnDTO> orders = await _orderService.Get();

            return Ok(orders);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> Get(int id)
        {
            OrderToReturnDTO order = await _orderService.Get(id);

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderToCreateDTO orderToCreate)
        {
            OrderToReturnDTO order = _orderService.Post(orderToCreate);

            return CreatedAtRoute("GetOrder", new { Id = order.OrderId }, order);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderToCreateDTO orderToCreate)
        {
            if (_orderService.Put(orderToCreate, id))
            {
                return NoContent();
            }
            return BadRequest("Fail to update Order");
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _orderService.Delete(id))
            {
                return NoContent();
            }
            return BadRequest("Fail to delete Product");
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> ProductsOfOrder(int id)
        {
            var products = await _orderService.ProductsOfOrder(id);
            if (products == null)
            {
                return NoContent();
            }

            return Ok(products);
        }

        [HttpPut("id/products")]
        public async Task<IActionResult> PutProductToOrder(int id, [FromBody] ProductToCreateDTO productToCreate)
        {
            var order = await _orderService.Get(id);
            if (await _orderService.PutProductToOrder(productToCreate, id))
            {
                return NoContent();
            }
            return BadRequest("Fail to update Order");
        }
    }
}
