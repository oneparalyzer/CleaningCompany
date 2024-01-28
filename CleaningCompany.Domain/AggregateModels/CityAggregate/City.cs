using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.CityAggregate;

public sealed class City : AggregateRoot<CityId>
{
    private City(CityId id, string title, RegionId regionId) : base(id)
    {
        Title = title;
        RegionId = regionId;
    }

    public string Title { get; private set; }
    public RegionId RegionId { get; private set; }

    public static City Create(string title, RegionId regionId)
    {
        return new City(CityId.Create(), title, regionId);
    }

    public void Update(string newTitle, RegionId newRegionId)
    {
        Title = newTitle;
        RegionId = newRegionId;
    }
}
