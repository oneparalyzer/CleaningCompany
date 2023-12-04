using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class PriceListPositionConfiguration : IEntityTypeConfiguration<PriceListPosition>
{
    public void Configure(EntityTypeBuilder<PriceListPosition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => PriceListPositionId.Create(value));

        builder.Property(x => x.ServiceId)
            .HasConversion(
                id => id.Value,
                value => ServiceId.Create(value));

        builder.OwnsOne(x => x.Price).Property(x => x.Value).IsRequired();

        builder.HasOne<Service>().WithMany().HasForeignKey(x => x.ServiceId);
    }
}
