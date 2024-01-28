using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Streets.Responses;

namespace CleaningCompany.Application.CQRS.Streets.Queries.GetAllByCityId;

public record GetAllStreetsByCityIdQuery(
    Guid CityId) : IQuery<List<GetAllStreetsResponse>>;
