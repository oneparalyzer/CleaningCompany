using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;

public sealed class CityId : Id
{
    private CityId(Guid value) : base(value) { }

    public static CityId Create()
    {
        return new CityId(Guid.NewGuid());
    }

    public static CityId Create(Guid value)
    {
        return new CityId(value);
    }
}
