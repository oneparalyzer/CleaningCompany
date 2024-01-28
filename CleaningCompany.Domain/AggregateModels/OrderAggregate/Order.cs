using CleaningCompany.Domain.AggregateModels.AddressAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Enumerations;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.SeedWorks;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Domain.AggregateModels.OrderAggregate;

public sealed class Order : AggregateRoot<OrderId>
{
    private Guid _clientId;

    private readonly List<OrderStatus> _statuses;
    private readonly List<OrderPosition> _positions;

    private Order(OrderId id) : base(id) { }

    private Order(
        OrderId id, 
        UserId clientId, 
        List<OrderPosition> positions,
        DateTime createdDate,
        AddressId addressId,
        Price price,
        List<OrderStatus> statuses) : base(id)

    {
        _positions = positions;
        ClientId = clientId;
        CreatedDate = createdDate;
        AddressId = addressId;
        Price = price;
        _statuses = statuses;
    }
    

    public UserId ClientId
    {
        get => UserId.Create(_clientId); 
        private set => _clientId = value.Value;
    }

    public DateTime CreatedDate { get; private set; }
    public AddressId AddressId { get; private set; }
    public Price Price { get; private set; }

    public IReadOnlyCollection<OrderStatus> Statuses => _statuses.AsReadOnly();
    public IReadOnlyList<OrderPosition> Positions => _positions.AsReadOnly();

    public static Result<Order> Create(
        UserId clientId,
        List<OrderPosition> positions,
        AddressId addressId)
    {
        Result validateItemsResult = Validate(positions);

        if (!validateItemsResult.IsSuccess)
        {
            return Result.Failure<Order>(
                validateItemsResult.Errors);
        }

        var statuses = new List<OrderStatus>()
        {
            OrderStatus.Create(OrderStatusTitle.Adopted)
        };

        Price price = CalculatePrice(positions);

        var order = new Order(
            OrderId.Create(),
            clientId,
            positions,
            DateTime.UtcNow,
            addressId,
            price,
            statuses);

        return Result.Success(order);
    }

    private static Price CalculatePrice(List<OrderPosition> positions)
    {
        decimal price = 0;

        foreach (var position in positions)
        {
            price += position.Price.Value;
        }

        return Price.Create(price);
    }

    private static Result Validate(List<OrderPosition> positions)
    {
        throw new NotImplementedException();
    }

    public void EmployeeHasBeenIdentified()
    {
        _statuses.Add(OrderStatus.Create(
            OrderStatusTitle.EmployeeHasBeenIdentified));
    }

    public bool IsCompleted()
    {
        return _statuses.FirstOrDefault(x =>
            x.Title == OrderStatusTitle.Completed) is not null;
    }

    public bool IsNew()
    {
        int countStatusesToBeNew = 1;

        return _statuses.Count == countStatusesToBeNew;
    }

    public OrderStatus GetLastStatus()
    {
        return _statuses[_statuses.Count - 1];
    }

    public Result Completed()
    {
        OrderStatus? statusComplete = _statuses.FirstOrDefault(x =>
            x.Title == OrderStatusTitle.Completed);

        if (statusComplete is not null)
        {
            return Result.Failure(Errors.Order
                .AlreadyCompleted()
                .ToList());
        }

        OrderStatus? statusEmployeeIdentified = _statuses.FirstOrDefault(x =>
            x.Title == OrderStatusTitle.EmployeeHasBeenIdentified);

        if (statusEmployeeIdentified is null)
        {
            return Result.Failure(Errors.Order
                .EmployeeHasNotBeenIdentified()
                .ToList());
        }

        _statuses.Add(OrderStatus.Create(
            OrderStatusTitle.Completed));

        return Result.Success();
    }
}
