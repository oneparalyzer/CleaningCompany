using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;

public sealed class StreetId : Id
{
    private StreetId(Guid value) : base(value) { }

    public static StreetId Create()
    {
        return new StreetId(Guid.NewGuid());
    }

    public static StreetId Create(Guid value)
    {
        return new StreetId(value);
    }
}
