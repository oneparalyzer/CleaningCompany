using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;

public sealed class PriceListId : Id
{
    private PriceListId(Guid value) : base(value) { }

    public static PriceListId Create()
    {
        return new PriceListId(Guid.NewGuid());
    }

    public static PriceListId Create(Guid value)
    {
        return new PriceListId(value);
    }
}
