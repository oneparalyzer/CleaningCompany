using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.AddressAggregate.ValueObjects;

public sealed class AddressId : Id
{
    private AddressId(Guid value) : base(value) { }

    public static AddressId Create()
    {
        return new AddressId(Guid.NewGuid());
    }

    public static AddressId Create(Guid value)
    {
        return new AddressId(value);
    }
}
