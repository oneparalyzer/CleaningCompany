using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Services.Commands.Update;

public record UpdateServiceCommand(
    Guid ServiceId,
    string NewTitle) : ICommand;
