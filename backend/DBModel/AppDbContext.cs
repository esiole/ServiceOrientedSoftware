global using DBModel.Interfaces;
global using DBModel.Models;
global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;

namespace DBModel;

public sealed class AppDbContext : DbContext
{
    public DbSet<CargoItem> CargoItems { get; set; } = null!;
    public DbSet<FromContact> FromContacts { get; set; } = null!;
    public DbSet<ToContact> ToContacts { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Vendor> Vendors { get; set; } = null!;
    public DbSet<VendorTariff> VendorTariffs { get; set; } = null!;
    public DbSet<Stats> Stats { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Order>()
            .HasOne(o => o.From)
            .WithOne(c => c.Order)
            .HasForeignKey<FromContact>(c => c.OrderId);
        
        modelBuilder
            .Entity<Order>()
            .HasOne(o => o.To)
            .WithOne(c => c.Order)
            .HasForeignKey<ToContact>(c => c.OrderId);

        modelBuilder.Entity<Vendor>().HasData(
            new Vendor { Id = 1, Name = "Почта России"},
            new Vendor { Id = 2, Name = "СДЭК" },
            new Vendor { Id = 3, Name = "КСЭ" }
        );
        
        modelBuilder.Entity<VendorTariff>().HasData(
            new VendorTariff { Id = 1, Name = "Письмо", VendorTariffId = "1", VendorId = 1 },
            new VendorTariff { Id = 2, Name = "Посылка", VendorTariffId = "2", VendorId = 1 },
            new VendorTariff { Id = 3, Name = "Супер-экспресс", VendorTariffId = "3", VendorId = 2 },
            new VendorTariff { Id = 4, Name = "Эконом", VendorTariffId = "4", VendorId = 3 },
            new VendorTariff { Id = 5, Name = "Сборный груз", VendorTariffId = "5", VendorId = 3 }
        );
        
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, VendorTariffId = 2, Description = "Посылка для друга" },
            new Order { Id = 2, VendorTariffId = 5, Description = "Партия ноутбуков" }
        );
        
        modelBuilder.Entity<FromContact>().HasData(
            new FromContact { Id = 1, OrderId = 1, CityName = "Санкт-Петербург", Address = "Невский проспект 15", ContactPersonName = "Иванов Иван Петрович" },
            new FromContact { Id = 2, OrderId = 2, CityName = "Новгород", Address = "Садовая улица 23", ContactPersonName = "Соколов Пётр Сергеевич" }
        );
        
        modelBuilder.Entity<ToContact>().HasData(
            new ToContact { Id = 1, OrderId = 1, CityName = "Москва", Address = "Тверская ул., д. 15", ContactPersonName = "Петров Сергей Иванович" },
            new ToContact { Id = 2, OrderId = 2, CityName = "Волгоград", Address = "Цветочная улица 36", ContactPersonName = "Сергеев Илья Иванович" }
        );
        
        modelBuilder.Entity<CargoItem>().HasData(
            new CargoItem { Id = 1, OrderId = 1, Length = 50, Width = 50, Height = 50, Weight = 5, Qty = 3 },
            new CargoItem { Id = 2, OrderId = 2, Length = 50, Width = 30, Height = 10, Weight = 3, Qty = 10 },
            new CargoItem { Id = 3, OrderId = 2, Length = 50, Width = 25, Height = 12, Weight = 2.4, Qty = 8 }
        );
    }
}