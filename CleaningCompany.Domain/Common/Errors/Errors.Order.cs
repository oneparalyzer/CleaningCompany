using CleaningCompany.Domain.Common.Errors;

namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class Order
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "Order.NotFoundById",
            message: "заказ не найден.",
            field: "orderId",
            fieldValue: fieldValue);

        public static Error AlreadyCompleted() => new Error(
            code: "Order.AlreadyCompleted",
            message: "Заказ уже завершен.");

        public static Error EmployeeHasNotBeenIdentified() => new Error(
            code: "Order.EmployeeHasNotBeenIdentified",
            message: "Для завершения заказа нужно назначить работника.");
    }
}
