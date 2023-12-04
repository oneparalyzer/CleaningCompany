using CleaningCompany.Domain.AggregateModels.PriceListAggregate;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class PriceListConfiguration : IEntityTypeConfiguration<PriceList>
{
    public void Configure(EntityTypeBuilder<PriceList> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => PriceListId.Create(value));

        builder.Property(x => x.CreatedDate).IsRequired();

        builder.Ignore(x => x.EmployeeId);

        builder.HasMany(x => x.Positions).WithOne().HasForeignKey("_priceListId");

        builder.HasOne<CustomIdentityUser>().WithMany().HasForeignKey("_employeeId");
    }
}
