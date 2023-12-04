using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Regions.Responses;

namespace CleaningCompany.Application.CQRS.Regions.Queries.GetAll;

public record GetAllRegionsQuery() : IQuery<IEnumerable<GetAllRegionsResponse>>;
