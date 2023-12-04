using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class Service
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "Service.NotFoundById",
            message: "Услуга не найдена.",
            field: "serviceId",
            fieldValue: fieldValue);

        public static Error AlreadyExistByTitle(string fieldValue) => new Error(
            code: "Service.NoAlreadyExistByTitletFoundById",
            message: $"Услуга с названием: '{fieldValue}' уже существует.",
            field: "title",
            fieldValue: fieldValue);
    }
}
