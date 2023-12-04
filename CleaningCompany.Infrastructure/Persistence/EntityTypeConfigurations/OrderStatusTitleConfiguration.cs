using CleaningCompany.Domain.AggregateModels.OrderAggregate.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleaningCompany.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class OrderStatusTitleConfiguration : IEntityTypeConfiguration<OrderStatusTitle>
{
    public void Configure(EntityTypeBuilder<OrderStatusTitle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
    }
}
