using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;

public sealed class ServiceId : Id
{
    private ServiceId(Guid value) : base(value) { }

    public static ServiceId Create()
    {
        return new ServiceId(Guid.NewGuid());
    }

    public static ServiceId Create(Guid value)
    {
        return new ServiceId(value);
    }
}
