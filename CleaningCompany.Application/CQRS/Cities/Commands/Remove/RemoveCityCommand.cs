using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Remove;

public record RemoveCityCommand(
    Guid CityId) : ICommand;
