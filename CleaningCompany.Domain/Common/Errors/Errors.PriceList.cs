using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class PriceList
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "PriceList.NotFoundById",
            message: "Прайс-лист не найдена.",
            field: "priceListId",
            fieldValue: fieldValue);
    }
}
