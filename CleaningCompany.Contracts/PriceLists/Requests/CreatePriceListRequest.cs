using System.Windows.Input;

namespace CleaningCompany.Contracts.PriceLists.Requests;

public class CreatePriceListRequest
{
    public List<CreatePriceListPositionRequest> Positions { get; set; }
}

public class CreatePriceListPositionRequest
{
    public Guid ServiceId { get; set; }
    public decimal Price { get; set; }
}
