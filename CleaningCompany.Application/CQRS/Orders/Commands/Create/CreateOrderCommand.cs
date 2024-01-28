using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using System.Security.Claims;

namespace CleaningCompany.Application.CQRS.Orders.Commands.Create;

public record CreateOrderCommand(
    ClaimsPrincipal User,
    List<CreateOrderPositionsCommand> Positions,
    Guid AddressId) : ICommand;

public record CreateOrderPositionsCommand(
    Guid PriceListPositionId,
    int Quantity,
    decimal Price); 