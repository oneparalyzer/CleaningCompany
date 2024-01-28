namespace CleaningCompany.Contracts.Streets.Responses;

public class GetAllStreetsResponse
{
    public Guid StreetId { get; set; }
    public string Title { get; set; }
    public Guid CityId { get; set; }
}
