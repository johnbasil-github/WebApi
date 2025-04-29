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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderContoller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderContoller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderContoller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
