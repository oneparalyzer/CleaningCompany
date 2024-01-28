using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Remove;

public record RemoveStreetCommand(
    Guid StreetId) : ICommand;
