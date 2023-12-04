using CleaningCompany.Domain.AggregateModels.OrderAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class OrderEmployeeConfiguration : IEntityTypeConfiguration<OrderEmployee>
{
    public void Configure(EntityTypeBuilder<OrderEmployee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => OrderEmployeeId.Create(value));

        builder.Ignore(x => x.EmployeeWhoApprovedId);

        builder.Ignore(x => x.EmployeeWhoPerformedId);

        builder.Property(x => x.OrderId)
            .HasConversion(
                id => id.Value,
                value => OrderId.Create(value));

        builder.HasOne<Order>().WithMany().HasForeignKey(x => x.OrderId);

        builder.HasOne<CustomIdentityUser>().WithMany().HasForeignKey("_employeeWhoApprovedId");

        builder.HasOne<CustomIdentityUser>().WithMany().HasForeignKey("_employeeWhoPerformedId");
    }
}
