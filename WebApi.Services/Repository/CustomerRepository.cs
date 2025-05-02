using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entity.Data;
using WebApi.Entity.Ḍto;
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

        public async Task<List<CustomerResponseDto>> GetAllCustomersAsync()
        {
            var customers = await (from cust  in _context.Customers
                                   join ord in _context.Orderss
                                   on cust.CustomerId equals ord.CustId
                                   select new CustomerResponseDto
                                   {
                                       CustomerId = cust.CustomerId,
                                       CustomerName = cust.CustomerName,
                                       OrderId = ord.OrderId,
                                       ProductName = ord.ProductName,
                                       Qty = ord.Qty,
                                       Total = ord.Total,
                                       TotalPrice = ord.TotalPrice,
                                       
                                   }).ToListAsync();
              //return await _context.Customers.ToListAsync();

            return customers;
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
