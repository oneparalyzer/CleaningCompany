using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;

public sealed class RegionId : Id
{
    private RegionId(Guid value) : base(value) { }

    public static RegionId Create()
    {
        return new RegionId(Guid.NewGuid());
    }

    public static RegionId Create(Guid value)
    {
        return new RegionId(value);
    }
}
