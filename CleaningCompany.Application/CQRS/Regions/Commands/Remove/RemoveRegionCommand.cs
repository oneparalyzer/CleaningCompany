using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Remove;

public record RemoveRegionCommand(Guid RegionId) : ICommand;
