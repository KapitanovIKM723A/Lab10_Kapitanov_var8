using Lab10_Kapitanov_var8.Infrastructure;
using Lab10_Kapitanov_var8.Infrastructure.Repositories;
using Lab10_Kapitanov_var8.Infrastructure.ExternalApis;
using Lab10_Kapitanov_var8.Domain.Interfaces;
using Lab10_Kapitanov_var8.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddHttpClient<DrugInfoRepository>();
builder.Services.AddScoped<DrugInfoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
