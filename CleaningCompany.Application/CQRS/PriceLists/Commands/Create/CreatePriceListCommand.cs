using CleaningCompany.Application.Common.Interfaces.Mediator;
using System.Security.Claims;

namespace CleaningCompany.Application.CQRS.PriceLists.Commands.Create;

public record CreatePriceListCommand(
    ClaimsPrincipal User,
    List<CreatePriceListPositionCommand> Positions) : ICommand;

public record CreatePriceListPositionCommand(
    Guid ServiceId,
    decimal Price);
