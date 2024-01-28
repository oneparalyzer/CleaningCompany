using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.AddressAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.Errors;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;
using System.Security.Claims;

namespace CleaningCompany.Application.CQRS.Orders.Commands.Create;

public sealed class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        CreateOrderCommand command, 
        CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        Claim? userIdClaim = command.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            errors.Add(Errors.User.CannotBeIdentified());
        }

        Guid userId = Guid.Parse(userIdClaim.Value);

        var positions = new List<OrderPosition>();

        decimal price = 0;

        foreach (var positionCommad in command.Positions)
        {
            PriceListPosition? pricelistPosition = await _unitOfWork.PriceListRepository
                .GetPositionByIdAsync(
                    PriceListPositionId.Create(positionCommad.PriceListPositionId),
                    cancellationToken);

            if (pricelistPosition is null)
            {
                errors.Add(Errors.PriceListPosition
                    .NotFoundById(positionCommad.PriceListPositionId.ToString()));
            }

            price += pricelistPosition.Price.Value * positionCommad.Quantity;

            positions.Add(OrderPosition.Create(
                pricelistPosition.Id,
                positionCommad.Quantity,
                Price.Create(pricelistPosition.Price.Value * positionCommad.Quantity)));
        }

        Result<Order> createOrderResult = Order.Create(
            UserId.Create(userId), 
            positions, 
            AddressId.Create(command.AddressId));

        if (!createOrderResult.IsSuccess)
        {
            errors.AddRange(createOrderResult.Errors);
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        await _unitOfWork.OrderRepository
            .CreateAsync(createOrderResult.Value, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
