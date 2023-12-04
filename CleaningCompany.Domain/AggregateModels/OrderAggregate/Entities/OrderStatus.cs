using CleaningCompany.Domain.AggregateModels.OrderAggregate.Enumerations;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;

public sealed class OrderStatus : Entity<OrderStatusId>
{
    private OrderStatus(OrderStatusId id) : base(id) { }

    private OrderStatus(
        OrderStatusId id, 
        OrderStatusTitle title, 
        DateTime createdDate) : base(id)
    {
        Title = title;
        CreatedDate = createdDate;
    }

    public OrderStatusTitle Title { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public static OrderStatus Create(OrderStatusTitle title)
    {
        return new OrderStatus(
            OrderStatusId.Create(),
            title,
            DateTime.Now);
    }
}
