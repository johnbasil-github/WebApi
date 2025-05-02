using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entity.Ḍto;
using WebApi.Entity.Models;

namespace WebApi.Services.Repository
{
    public interface ICustomerRepository
    {
        Task <List<CustomerResponseDto>> GetAllCustomersAsync();
        Task<Customers?> GetCustomerByIdAsync(int id);

        Task AddCustomerAsync(Customers customers);

        Task UpdateCustomerAsync(int id, Customers customers);
        Task DeleteCustomerAsync(int id);
    }
}
