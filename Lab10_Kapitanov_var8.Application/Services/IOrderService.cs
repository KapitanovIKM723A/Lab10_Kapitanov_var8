using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_Kapitanov_var8.Domain.Entities;

namespace Lab10_Kapitanov_var8.Application.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task PlaceOrderAsync(Order order);
        Task UpdateAsync(Order order);
        Task CancelAsync(int id);
    }
}
