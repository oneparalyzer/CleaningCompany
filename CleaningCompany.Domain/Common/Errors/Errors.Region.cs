using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class Region
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "Region.NotFoundById",
            message: "Регион не найден.",
            field: "regionId",
            fieldValue: fieldValue);

        public static Error AlreadyExistByTitle(string fieldValue) => new Error(
            code: "Region.NoAlreadyExistByTitletFoundById",
            message: $"Регион с названием: '{fieldValue}' уже существует.",
            field: "title",
            fieldValue: fieldValue);
    }
}
