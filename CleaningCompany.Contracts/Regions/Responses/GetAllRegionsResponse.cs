namespace CleaningCompany.Contracts.Regions.Responses;

public class GetAllRegionsResponse
{
    public Guid RegionId { get; set; }
    public string Title { get; set; } = null!;
}
