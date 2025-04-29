using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity.Models;

namespace WebApi.Services.Repository
{
    public interface IOrderRepository
    {

        Task<List<Orderss>> GetAllordersAsync();
        Task<Orderss?> GetOrderByIdAsync(int id);

        Task AddorderAsync(Orderss orderss);

        Task UpdateOrderAsync(int id, Orderss orderss);
        Task DeleteOrderAsync(int id);
    }
}
