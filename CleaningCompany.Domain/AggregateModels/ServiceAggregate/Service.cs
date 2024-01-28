using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.ServiceAggregate;

public sealed class Service : AggregateRoot<ServiceId>
{
    private Service(ServiceId id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }

    public static Service Create(string title)
    {
        return new Service(ServiceId.Create(), title);
    }

    public void Update(string newTitle)
    {
        Title = newTitle;
    }
}
