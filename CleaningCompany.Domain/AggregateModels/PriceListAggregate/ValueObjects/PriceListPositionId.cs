using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;

public sealed class PriceListPositionId : Id
{
    private PriceListPositionId(Guid value) : base(value) { }

    public static PriceListPositionId Create()
    {
        return new PriceListPositionId(Guid.NewGuid());
    }

    public static PriceListPositionId Create(Guid value)
    {
        return new PriceListPositionId(value);
    }
}
