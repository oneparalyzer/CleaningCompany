using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.RegionAggregate;

public sealed class Region : AggregateRoot<RegionId>
{
    private Region(RegionId id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }

    public static Region Create(string title)
    {
        return new Region(RegionId.Create(), title);
    }

    public void Update(string newTitle)
    {
        Title = newTitle;
    }
}
