using Microsoft.EntityFrameworkCore;
using Lab10_Kapitanov_var8.Domain.Entities;
using Lab10_Kapitanov_var8.Domain.Interfaces;

namespace Lab10_Kapitanov_var8.Infrastructure.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _db;
        public MedicineRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Medicine>> GetAllAsync() =>
            await _db.Medicines.ToListAsync();

        public async Task<Medicine?> GetByIdAsync(int id) =>
            await _db.Medicines.FindAsync(id);

        public async Task AddAsync(Medicine entity)
        {
            _db.Medicines.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medicine entity)
        {
            _db.Medicines.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var m = await _db.Medicines.FindAsync(id);
            if (m is not null)
            {
                _db.Medicines.Remove(m);
                await _db.SaveChangesAsync();
            }
        }
    }
}
