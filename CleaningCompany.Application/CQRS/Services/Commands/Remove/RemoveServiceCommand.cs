using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Services.Commands.Remove;

public record RemoveServiceCommand(
    Guid ServiceId) : ICommand;
