using Microsoft.EntityFrameworkCore;
using Lab10_Kapitanov_var8.Domain.Entities;

namespace Lab10_Kapitanov_var8.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Medicine> Medicines { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
    }
}