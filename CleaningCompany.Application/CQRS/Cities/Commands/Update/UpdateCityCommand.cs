using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Update;

public record UpdateCityCommand(
    Guid CityId,
    string NewTitle,
    Guid NewRegionId) : ICommand;
