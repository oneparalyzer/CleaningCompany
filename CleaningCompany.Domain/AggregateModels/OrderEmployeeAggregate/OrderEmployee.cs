using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate.DomainEvents;
using CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate;

public sealed class OrderEmployee : AggregateRoot<OrderEmployeeId>
{
    private Guid _employeeWhoApprovedId;
    private Guid _employeeWhoPerformedId;

    private OrderEmployee(OrderEmployeeId id) : base(id) { }

    private OrderEmployee(
        OrderEmployeeId id,
        UserId employeeWhoApprovedId,
        UserId employeeWhoPerformedId,
        OrderId orderId) : base(id)
    {
        EmployeeWhoApprovedId = employeeWhoApprovedId;
        EmployeeWhoPerformedId = employeeWhoPerformedId;
        OrderId = orderId;
    }

    public UserId EmployeeWhoPerformedId
    {
        get => UserId.Create(_employeeWhoPerformedId);
        private set => _employeeWhoPerformedId = value.Value;
    }


    public UserId EmployeeWhoApprovedId
    {
        get => UserId.Create(_employeeWhoApprovedId);
        private set => _employeeWhoApprovedId = value.Value;
    }
    public OrderId OrderId { get; private set; }

    public static OrderEmployee Create(
        UserId employeeWhoApprovedId,
        UserId employeeWhoPerformedId,
        OrderId orderId)
    {
        var orderEmployee = new OrderEmployee(
            OrderEmployeeId.Create(),
            employeeWhoApprovedId,
            employeeWhoPerformedId,
            orderId);

        orderEmployee.AddDomainEvent(
            new OrderEmployeeHasBeenIdentifiedDomainEvent(orderEmployee));

        return orderEmployee;
    }
}
