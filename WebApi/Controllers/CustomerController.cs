using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApi.Entity.Data;
using WebApi.Entity.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<Customers>> Get()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Customers> Get(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task Post([FromBody] Customers customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Customers customer)
        {

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var person = _context.Customers.Find(id);

            _context.Customers.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}