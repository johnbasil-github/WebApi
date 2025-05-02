using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entity.Data;
using WebApi.Entity.Models;
using WebApi.Services.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IOrderRepository _orderRepository;
        public OrderController(IOrderRepository repository)
        {
            _orderRepository = repository;
        }


        // GET: api/<OrderContoller>
        [HttpGet("GetAllOrders")]
        public  async Task<IActionResult> GetAllOrders()
        {
            return Ok (await  _orderRepository.GetAllordersAsync());

        }

        // GET api/<OrderContoller>/5
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await _orderRepository.GetOrderByIdAsync(id));
        }

        // POST api/<OrderContoller>
        [HttpPost("Addorder")]
        public async Task<IActionResult> Addorder([FromBody] Orderss orderss)
        {
            await _orderRepository.AddorderAsync(orderss);

            return Ok();
        }

        // PUT api/<OrderContoller>/5
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Orderss orderss)
        {
            if (orderss == null)
            {
                return BadRequest("No content from the request");
            }

            await _orderRepository.UpdateOrderAsync(id, orderss);
            return Ok();
        }

        // DELETE api/<OrderContoller>/5
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
