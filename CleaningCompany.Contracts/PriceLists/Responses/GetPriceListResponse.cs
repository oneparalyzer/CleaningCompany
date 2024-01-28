namespace CleaningCompany.Contracts.PriceLists.Responses;

public class GetPriceListResponse
{
    public Guid PriceListId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EmployeeSurname { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeePatronymic { get; set; }
    public virtual List<GetPositionsByPriceListByIdResponse> Positions { get; set; }
}

public class GetPositionsByPriceListByIdResponse
{
    public Guid PositionId { get; set; }
    public decimal Price { get; set; }
    public Guid ServiceId { get; set; }
    public string ServiceTitle { get; set; }
}
