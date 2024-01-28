using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Cities.Responses;

namespace CleaningCompany.Application.CQRS.Cities.Queries.GetAllByRegionId;

public record GetAllCitiesByRegionIdQuery(
    Guid RegionId) : IQuery<List<GetAllCitiesResponse>>;
