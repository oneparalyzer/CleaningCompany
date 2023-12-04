using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;

public sealed class PriceListPosition : Entity<PriceListPositionId>
{
    private PriceListId _priceListId;

    private PriceListPosition(PriceListPositionId id) : base(id) { }

    private PriceListPosition(PriceListPositionId id, ServiceId serviceId, Price price) : base(id)
    {
        ServiceId = serviceId;
        Price = price;
    }

    public ServiceId ServiceId { get; private set; }
    public Price Price { get; private set; }

    public static PriceListPosition Create(ServiceId serviceId, Price price)
    {
        return new PriceListPosition(PriceListPositionId.Create(), serviceId, price);
    }
}
