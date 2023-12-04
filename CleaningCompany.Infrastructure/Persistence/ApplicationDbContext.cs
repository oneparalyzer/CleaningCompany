using CleaningCompany.Domain.AggregateModels.AddressAggregate;
using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Enumerations;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleaningCompany.Infrastructure.Persistence;

public sealed class ApplicationDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, Guid>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<PriceList> PriceLists { get; set; }
    public DbSet<PriceListPosition> PriceListPositions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPosition> OrderPositions { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<OrderStatusTitle> OrderStatusTitles { get; set; }
    public DbSet<OrderEmployee> OrderEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        DataSeeder.Seed(builder);
    }
}
