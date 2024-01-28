namespace CleaningCompany.Contracts.Addresses.Responses;

public class GetAllAddressesResponse
{
    public Guid AddressId { get; set; }
    public string Home { get; set; }
    public string? Building { get; set; }
    public string Apartments { get; set; }
    public string? Room { get; set; }
    public Guid StreetId { get; set; }
}
