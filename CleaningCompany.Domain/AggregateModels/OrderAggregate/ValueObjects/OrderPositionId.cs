using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;

public sealed class OrderPositionId : Id
{
    private OrderPositionId(Guid value) : base(value) { }

    public static OrderPositionId Create()
    {
        return new OrderPositionId(Guid.NewGuid());
    }

    public static OrderPositionId Create(Guid value)
    {
        return new OrderPositionId(value);
    }
}
