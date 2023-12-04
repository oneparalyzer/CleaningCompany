using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;

public sealed class OrderPosition : Entity<OrderPositionId>
{
    private OrderId _orderId;

    private OrderPosition(OrderPositionId id) : base(id) { }

    private OrderPosition(
        OrderPositionId id,
        PriceListPositionId priceListPositionId,
        int quantity,
        Price price) : base(id)
    {
        PriceListPositionId = priceListPositionId;
        Quantity = quantity;
        Price = price;
    }

    public PriceListPositionId PriceListPositionId { get; private set; }
    public int Quantity { get; private set; }
    public Price Price { get; private set; }

    public static OrderPosition Create(
        PriceListPositionId priceListPositionId,
        int quantity,
        Price price)
    {
        return new OrderPosition(
            OrderPositionId.Create(),
            priceListPositionId,
            quantity,
            price);
    }
}
