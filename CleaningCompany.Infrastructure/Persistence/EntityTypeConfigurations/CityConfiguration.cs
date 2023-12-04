using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => CityId.Create(value));

        builder.Property(x => x.RegionId)
            .HasConversion(
                id => id.Value,
                value => RegionId.Create(value));

        builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();

        builder.Ignore(x => x.DomainEvents);

        builder.HasOne<Region>().WithMany().HasForeignKey(x => x.RegionId);
    }
}
