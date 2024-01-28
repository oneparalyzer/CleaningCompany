using CleaningCompany.Domain.AggregateModels.AddressAggregate;
using CleaningCompany.Domain.AggregateModels.AddressAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => OrderId.Create(value));

        builder.Ignore(x => x.ClientId);
            

        builder.Property(x => x.AddressId)
            .HasConversion(
                id => id.Value,
                value => AddressId.Create(value));

        builder.OwnsOne(x => x.Price).Property(x => x.Value).IsRequired();

        builder.Property(x => x.CreatedDate).IsRequired();

        builder.HasMany(x => x.Positions).WithOne().HasForeignKey("_orderId");
        builder.HasMany(x => x.Statuses).WithMany();
        builder.HasOne<Address>().WithMany().HasForeignKey(x => x.AddressId);

        builder.HasOne<CustomIdentityUser>().WithMany().HasForeignKey("_clientId");

        builder.Ignore(x => x.DomainEvents);
    }
}
