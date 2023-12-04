using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Create;

public record CreateRegionCommand(
    string Title) : ICommand;
