using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Services.Responses;

namespace CleaningCompany.Application.CQRS.Services.Queries.GetAll;

public record GetAllServicesQuery() : IQuery<List<GetAllServicesResponse>>;
