using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate.ValueObjects;

public sealed class OrderEmployeeId : Id
{
    private OrderEmployeeId(Guid value) : base(value) { }

    public static OrderEmployeeId Create()
    {
        return new OrderEmployeeId(Guid.NewGuid());
    }

    public static OrderEmployeeId Create(Guid value)
    {
        return new OrderEmployeeId(value);
    }
}
