using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.OrderAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate.DomainEvents;
using MediatR;

namespace CleaningCompany.Application.CQRS.OrderEmployees.Events;

public sealed class OrderEmployeeHasBeenIdentifiedDomainEventHandler
    : INotificationHandler<OrderEmployeeHasBeenIdentifiedDomainEvent>
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderEmployeeHasBeenIdentifiedDomainEventHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        OrderEmployeeHasBeenIdentifiedDomainEvent domainEvent, 
        CancellationToken cancellationToken)
    {
        OrderId orderId = domainEvent.OrderEmployee.OrderId;

        Order? orderById = await _unitOfWork.OrderRepository
            .GetByIdAsync(orderId, cancellationToken);

        if (orderById is null)
        {
            throw new ArgumentNullException(nameof(orderById)); 
        }

        orderById.EmployeeHasBeenIdentified();

        await _unitOfWork.OrderRepository
            .UpdateAsync(
                orderById, 
                cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
