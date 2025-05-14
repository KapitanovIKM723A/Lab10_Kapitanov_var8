using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_Kapitanov_var8.Domain.Entities;

namespace Lab10_Kapitanov_var8.Application.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task<Medicine?> GetByIdAsync(int id);
        Task AddAsync(Medicine medicine);
        Task UpdateAsync(Medicine medicine);
        Task DeleteAsync(int id);
    }
}
