using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class City
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "City.NotFoundById",
            message: "Город не найден.",
            field: "cityId",
            fieldValue: fieldValue);

        public static Error AlreadyExistByTitle(string fieldValue) => new Error(
            code: "City.NoAlreadyExistByTitletFoundById",
            message: $"Город с названием: '{fieldValue}' уже существует.",
            field: "title",
            fieldValue: fieldValue);
    }
}
