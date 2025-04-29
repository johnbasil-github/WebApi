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
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;

        }


        public async Task<List<Orderss>> GetAllordersAsync()
        {
            return await _context.Orderss.ToListAsync();
        }

        public async Task<Orderss?> GetOrderByIdAsync(int id)
        {
            return await _context.Orderss.FindAsync(id);
        }

        public async Task AddorderAsync(Orderss orderss)
        {
            _context.Orderss.Add(orderss);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(int id, Orderss orderss)
        {
            _context.Orderss.Update(orderss);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var val = _context.Orderss.Find(id);

            _context.Orderss.Remove(val);
            await _context.SaveChangesAsync();
        }

    }
}
