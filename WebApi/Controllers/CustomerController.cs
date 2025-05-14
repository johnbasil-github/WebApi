using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;
using WebApi.Entity.Data;
using WebApi.Entity.Models;
using WebApi.Services.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerRepository _customerRepository;

        private ILogger<CustomerController> _logger;
        public CustomerController(ICustomerRepository repository,ILogger<CustomerController> logger)
        {
            _customerRepository = repository;
            _logger = logger;
        }

        // GET: api/<CustomerController>
        [HttpGet("GetAllCustomers")]
        //[Route("GetALlEmployees")]   we can also give like this, but we use above method, adding in httpmethod 
        public async Task<IActionResult> GetAllCustomers()
        {
            _logger.LogInformation("Entered on GEtAllCustomers");
            return Ok(await _customerRepository.GetAllCustomersAsync());
        }

        // GET api/<CustomerController>/5
        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await _customerRepository.GetCustomerByIdAsync(id));
        }

        // POST api/<CustomerController>
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customers customer)
        {
            await _customerRepository.AddCustomerAsync(customer);

            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customers customer)
        {
            if (customer == null)
            {
                return BadRequest("No content from the request");
            }

            await _customerRepository.UpdateCustomerAsync(id, customer);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}