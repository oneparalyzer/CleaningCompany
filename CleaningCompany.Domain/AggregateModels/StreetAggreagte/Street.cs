using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.StreetAggreagte;

public sealed class Street : AggregateRoot<StreetId>
{
    private Street(StreetId id, string title, CityId cityId) : base(id)
    {
        Title = title;
        CityId = cityId;
    }

    public string Title { get; private set; }
    public CityId CityId { get; private set; }

    public void Update(string newTitle, CityId newCityId)
    {
        Title = newTitle;
        CityId = newCityId;
    }

    public static Street Create(string title, CityId cityId)
    {
        return new Street(StreetId.Create(), title, cityId);
    }
}
