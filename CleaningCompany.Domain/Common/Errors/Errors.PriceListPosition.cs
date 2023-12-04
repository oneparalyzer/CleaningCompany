using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class PriceListPosition
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "PriceListPosition.NotFoundById",
            message: "Позиция прайс-листа не найдена.",
            field: "priceListPosition",
            fieldValue: fieldValue);

        public static Error CannotBeRepeatedByServiceId(string fieldValue) => new Error(
            code: "PriceListPosition.CannotBeRepeatedByServiceId",
            message: "Позиция прайс-листа не пожет повторяться.",
            field: "priceListPosition",
            fieldValue: fieldValue);
    }
}
