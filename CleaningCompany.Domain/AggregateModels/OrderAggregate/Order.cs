using CleaningCompany.Domain.AggregateModels.AddressAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Enumerations;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate;

public sealed class Order : AggregateRoot<OrderId>
{
    private Guid _clientId;

    private readonly List<OrderPosition> _positions;

    private Order(OrderId id) : base(id) { }

    private Order(
        OrderId id, 
        UserId clientId, 
        List<OrderPosition> positions,
        DateTime createdDate,
        AddressId addressId,
        Price price,
        OrderStatus orderStatus,
        OrderStatusId orderStatusId) : base(id)

    {
        _positions = positions;
        ClientId = clientId;
        CreatedDate = createdDate;
        AddressId = addressId;
        Price = price;
        OrderStatus = orderStatus;
        OrderStatusId = orderStatusId;
    }
    

    public UserId ClientId
    {
        get => UserId.Create(_clientId); 
        private set => _clientId = value.Value;
    }

    public DateTime CreatedDate { get; private set; }
    public AddressId AddressId { get; private set; }
    public Price Price { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public OrderStatusId OrderStatusId { get; private set; }

    public IReadOnlyList<OrderPosition> Positions => _positions.AsReadOnly();

    public static Result<Order> Create(
        UserId clientId,
        List<OrderPosition> positions,
        AddressId addressId,
        Price price)
    {
        Result validateItemsResult = Validate(positions);

        if (!validateItemsResult.IsSuccess)
        {
            return Result.Failure<Order>(
                validateItemsResult.Errors);
        }

        var orderStatus = OrderStatus.Create(
            OrderStatusTitle.Adopted);

        var order = new Order(
            OrderId.Create(),
            clientId,
            positions,
            DateTime.Now,
            addressId,
            price,
            orderStatus,
            orderStatus.Id);

        return Result.Success(order);
    }

    private static Result Validate(List<OrderPosition> items)
    {
        throw new NotImplementedException();
    }

    //jsfhfgbfdhvgb
    public void EmployeeHasBeenIdentified()
    {
        throw new NotImplementedException();
    }
}
