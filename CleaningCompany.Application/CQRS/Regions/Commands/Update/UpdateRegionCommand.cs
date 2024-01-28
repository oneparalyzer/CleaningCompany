using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Update;

public record UpdateRegionCommand(
    Guid RegionId,
    string NewTitle) : ICommand;
