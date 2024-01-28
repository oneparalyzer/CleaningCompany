namespace CleaningCompany.Contracts.Services.Requests;

public record UpdateServiceRequest(
    Guid ServiceId,
    string NewTitle);
