using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Create;

public record CreateStreetCommand(
    string Title,
    Guid CityId) : ICommand;
