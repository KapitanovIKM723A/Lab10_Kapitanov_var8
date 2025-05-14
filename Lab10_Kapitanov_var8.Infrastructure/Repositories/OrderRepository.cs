using Microsoft.EntityFrameworkCore;
using Lab10_Kapitanov_var8.Domain.Entities;
using Lab10_Kapitanov_var8.Domain.Interfaces;

namespace Lab10_Kapitanov_var8.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        public OrderRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _db.Orders
                     .Include(o => o.Items)
                     .ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) =>
            await _db.Orders
                     .Include(o => o.Items)
                     .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Order entity)
        {
            _db.Orders.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _db.Orders.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var o = await _db.Orders.FindAsync(id);
            if (o is not null)
            {
                _db.Orders.Remove(o);
                await _db.SaveChangesAsync();
            }
        }
    }
}
