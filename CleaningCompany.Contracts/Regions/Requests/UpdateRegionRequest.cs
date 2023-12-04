namespace CleaningCompany.Contracts.Regions.Requests;

public record UpdateRegionRequest(
    Guid RegionId,
    string Title);
