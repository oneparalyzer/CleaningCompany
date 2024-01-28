using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.PriceLists.Responses;

namespace CleaningCompany.Application.CQRS.PriceLists.Queries.GetAll;

public record GetAllPriceListsQuery() : IQuery<List<GetAllPriceListsResponse>>;
