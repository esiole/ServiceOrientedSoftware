global using API.Models;
global using DBModel;
global using DBModel.Models;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Caching.Distributed;
global using Services.Interfaces;
global using System.ComponentModel.DataAnnotations;
using DBModel.Interfaces;
using DBModel.Repositories;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var redisConnectStr = builder.Configuration.GetConnectionString("Redis");
var postgresConnectStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddStackExchangeRedisCache(options => options.Configuration = redisConnectStr);

builder.Services
    .AddDbContext<AppDbContext>(options => options
        .UseNpgsql(postgresConnectStr)
        .EnableSensitiveDataLogging()
    );

builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<IJsonCacheService, JsonCacheService>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IStatisticsService, StatisticsService>();
builder.Services.AddTransient<IVendorsService, VendorsService>();
builder.Services.AddTransient<IVendorTariffsService, VendorTariffsService>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IVendorsRepository, VendorsRepository>();
builder.Services.AddScoped<IVendorTariffsRepository, VendorTariffsRepository>();

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