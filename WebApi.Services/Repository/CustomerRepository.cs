using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entity.Data;
using WebApi.Entity.Models;

namespace WebApi.Services.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customers>> GetAllCustomersAsync()
        {
              return await _context.Customers.ToListAsync();
        }

        public async Task<Customers?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddCustomerAsync(Customers customers)
        {
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(int id, Customers customers)
        {
            _context.Customers.Update(customers);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var person = _context.Customers.Find(id);

            _context.Customers.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
