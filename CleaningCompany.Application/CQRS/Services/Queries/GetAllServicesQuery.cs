using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Services.Responses;

namespace CleaningCompany.Application.CQRS.Services.Queries;

public record GetAllServicesQuery() : IQuery<IEnumerable<GetAllServicesResponse>>;
