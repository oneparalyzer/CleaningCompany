using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Services.Commands.Create;

public record CreateServiceCommand(string Title) : ICommand;
