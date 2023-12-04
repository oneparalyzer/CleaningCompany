using CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class OrderPositionConfiguration : IEntityTypeConfiguration<OrderPosition>
{
    public void Configure(EntityTypeBuilder<OrderPosition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => OrderPositionId.Create(value));

        builder.Property(x => x.Price)
            .HasConversion(
                price => price.Value,
                value => Price.Create(value));

        builder.Property(x => x.PriceListPositionId)
            .HasConversion(
                id => id.Value,
                value => PriceListPositionId.Create(value));

        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne<PriceListPosition>().WithMany().HasForeignKey(x => x.PriceListPositionId);
    }
}
