using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Streets.Responses;

namespace CleaningCompany.Application.CQRS.Streets.Queries.GetAll;

public record GetAllStreetsQuery() : IQuery<List<GetAllStreetsResponse>>;
