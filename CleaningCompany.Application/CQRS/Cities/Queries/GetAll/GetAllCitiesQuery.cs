using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Cities.Responses;

namespace CleaningCompany.Application.CQRS.Cities.Queries.GetAll;

public record GetAllCitiesQuery() : IQuery<List<GetAllCitiesResponse>>;
