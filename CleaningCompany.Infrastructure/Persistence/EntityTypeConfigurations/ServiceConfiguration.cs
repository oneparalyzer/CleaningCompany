using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => ServiceId.Create(value));

        builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();

        builder.Ignore(x => x.DomainEvents);
    }
}
