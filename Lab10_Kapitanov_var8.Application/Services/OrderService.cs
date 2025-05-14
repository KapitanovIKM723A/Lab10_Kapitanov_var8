using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_Kapitanov_var8.Domain.Entities;
using Lab10_Kapitanov_var8.Domain.Interfaces;

namespace Lab10_Kapitanov_var8.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Order>> GetAllAsync() =>
            _repo.GetAllAsync();

        public Task<Order?> GetByIdAsync(int id) =>
            _repo.GetByIdAsync(id);

        public Task PlaceOrderAsync(Order order) =>
            _repo.AddAsync(order);

        public Task UpdateAsync(Order order) =>
            _repo.UpdateAsync(order);

        public Task CancelAsync(int id) =>
            _repo.DeleteAsync(id);
    }
}
