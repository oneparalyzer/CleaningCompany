using CleaningCompany.Domain.AggregateModels.AddressAggregate;
using CleaningCompany.Domain.AggregateModels.AddressAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => AddressId.Create(value));

        builder.Property(x => x.StreetId)
            .HasConversion(
                id => id.Value,
                value => StreetId.Create(value));

        builder.Property(x => x.Apartments).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Home).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Building).HasMaxLength(50);
        builder.Property(x => x.Room).HasMaxLength(50);

        builder.Ignore(x => x.DomainEvents);

        builder.HasOne<Street>().WithMany().HasForeignKey(x => x.StreetId);
    }
}
