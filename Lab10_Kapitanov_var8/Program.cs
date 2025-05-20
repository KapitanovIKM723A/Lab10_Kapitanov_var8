using Lab10_Kapitanov_var8.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

bool useInMemory = builder.Configuration.GetValue<bool>("UseInMemory");
if (useInMemory)
{
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseInMemoryDatabase("Lab10_InMemory"));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services
    .AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        opts.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Lab10_Kapitanov_var8 API",
        Version = "v1",
        Description = "Multi-layer ASP.NET Core API"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab10 Kapitanov API V1");
});

app.UseHttpsRedirection();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (useInMemory)
        db.Database.EnsureCreated();
    else
        db.Database.Migrate();

    DbSeeder.Seed(db);
}

app.MapControllers();
app.Run();