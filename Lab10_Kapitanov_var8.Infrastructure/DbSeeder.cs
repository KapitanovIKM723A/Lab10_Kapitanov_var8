using Lab10_Kapitanov_var8.Domain.Entities;

namespace Lab10_Kapitanov_var8.Infrastructure
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext ctx)
        {
            if (!ctx.Products.Any())
            {
                ctx.Products.AddRange(
                    new Product { Name = "Laptop", Price = 1000m, CategoryId = 1 },
                    new Product { Name = "Smartphone", Price = 500m, CategoryId = 1 },
                    new Product { Name = "ASP.NET Core Book", Price = 30m, CategoryId = 2 }
                );
                ctx.SaveChanges();
            }
        }
    }
}