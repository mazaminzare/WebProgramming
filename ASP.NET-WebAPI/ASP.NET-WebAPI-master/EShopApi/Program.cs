using EShopApi.Contracts;
using EShopApi.Models;
using EShopApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EShopApi_DBContext>(options => { options.UseSqlServer("Data Source=.\\SQL2016;Initial Catalog=EshopApi_DB;Integrated Security=True;"); });
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ISalesPersonsRepository, SalesPersonsRepository>();

builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
