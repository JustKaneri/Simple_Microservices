using Microsoft.EntityFrameworkCore;
using ServisProduct.Data;
using ServisProduct.Interface;
using ServisProduct.Model;
using ServisProduct.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("rabbitConfig.json");

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IProductRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository<TypeProduct>, ProductTypeRepository>();
builder.Services.AddScoped<IRabbitMQRepository, RabbitRepository>();

builder.Services.AddDbContext<DataContext>((options) =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpLogging();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }