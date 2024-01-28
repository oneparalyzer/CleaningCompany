namespace CleaningCompany.Contracts.Cities.Responses;

public class GetAllCitiesResponse
{
    public Guid CityId { get; set; }
    public string Title { get; set; }
    public Guid RegionId { get; set; }
}
