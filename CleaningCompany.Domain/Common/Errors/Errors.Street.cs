using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class Street
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "Street.NotFoundById",
            message: "Улица не найдена.",
            field: "streetId",
            fieldValue: fieldValue);

        public static Error AlreadyExistByTitle(string fieldValue) => new Error(
            code: "Street.NoAlreadyExistByTitletFoundById",
            message: $"Улица с названием: '{fieldValue}' уже существует.",
            field: "title",
            fieldValue: fieldValue);
    }
}
