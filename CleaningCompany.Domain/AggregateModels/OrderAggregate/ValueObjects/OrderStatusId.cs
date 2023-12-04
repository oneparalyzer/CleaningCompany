using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;

public sealed class OrderStatusId : Id
{
    public OrderStatusId(Guid value) : base(value) { }

    public static OrderStatusId Create()
    {
        return new OrderStatusId(Guid.NewGuid());
    }

    public static OrderStatusId Create(Guid value)
    {
        return new OrderStatusId(value);
    }
}
