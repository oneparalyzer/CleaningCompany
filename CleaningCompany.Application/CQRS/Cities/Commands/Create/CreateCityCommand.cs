using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Create;

public record CreateCityCommand(
    string Title,
    Guid RegionId) : ICommand;
