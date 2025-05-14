using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_Kapitanov_var8.Domain.Entities;
using Lab10_Kapitanov_var8.Domain.Interfaces;

namespace Lab10_Kapitanov_var8.Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repo;
        public MedicineService(IMedicineRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Medicine>> GetAllAsync() =>
            _repo.GetAllAsync();

        public Task<Medicine?> GetByIdAsync(int id) =>
            _repo.GetByIdAsync(id);

        public Task AddAsync(Medicine medicine) =>
            _repo.AddAsync(medicine);

        public Task UpdateAsync(Medicine medicine) =>
            _repo.UpdateAsync(medicine);

        public Task DeleteAsync(int id) =>
            _repo.DeleteAsync(id);
    }
}
