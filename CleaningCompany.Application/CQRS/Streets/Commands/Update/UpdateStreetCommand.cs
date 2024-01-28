using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Update;

public record UpdateStreetCommand(
    Guid StreetId,
    string NewTitle,
    Guid NewCityId) : ICommand;
