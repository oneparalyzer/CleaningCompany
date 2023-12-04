using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;

public sealed class OrderId : Id
{
    private OrderId(Guid value) : base(value) { }

    public static OrderId Create()
    {
        return new OrderId(Guid.NewGuid());
    }

    public static OrderId Create(Guid value)
    {
        return new OrderId(value);
    }
}
