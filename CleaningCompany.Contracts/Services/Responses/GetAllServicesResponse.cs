namespace CleaningCompany.Contracts.Services.Responses;

public class GetAllServicesResponse
{
    public Guid ServiceId { get; set; }
    public string Title { get; set; } = null!;
}
