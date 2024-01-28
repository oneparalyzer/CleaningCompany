using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate.Enumerations;

public sealed class OrderStatusTitle : Enumeration<int>
{
    private OrderStatusTitle(int id, string name) : base(id, name) { }

    public static readonly OrderStatusTitle Adopted = new(1, "Принят");
    public static readonly OrderStatusTitle EmployeeHasBeenIdentified = new(2, "Определен работник");
    public static readonly OrderStatusTitle Completed = new(3, "Завершен");
}
