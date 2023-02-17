using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WebApiStore.Context;
using WebApiStore.Entities;
using WebApiStore.Interfaces;
using WebApiStore.Dtos;
using WebApiStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataBaseContext>();

builder.Services.AddTransient<IProduct, ProductRepository>();
builder.Services.AddTransient<ITransaction, TransactionRepository>();
builder.Services.AddTransient<ITransactionDetail, TransactionDetailRepository>();

builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<Product, ProductDto>().ReverseMap();
    config.CreateMap<Transaction, TransactionDto>().ReverseMap();
    config.CreateMap<TransactionDetail, TransactionDetailDto>().ReverseMap();
    config.CreateMap<Product, ProductStockDto>();
});


builder.Services.AddControllers()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WebApiStore",
        Description = "Rest api in dotnet core for store",
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();



app.Run();
