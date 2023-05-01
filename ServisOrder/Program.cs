using Microsoft.EntityFrameworkCore;
using ServisOrder.BackgroundServis;
using ServisOrder.Data;
using ServisOrder.Interface;
using ServisOrder.Model;
using ServisOrder.Repository;
using ServisOrder.Servises;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("rabbitConfig.json");

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IOrderRepository<Order>, OrderRepository>();
builder.Services.AddScoped<ICasheRepository<UserCashe>, UserCasheRepository>();
builder.Services.AddSingleton<CreatorSingeltonServis>();

builder.Services.AddHostedService<UserRabbitServis>();


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