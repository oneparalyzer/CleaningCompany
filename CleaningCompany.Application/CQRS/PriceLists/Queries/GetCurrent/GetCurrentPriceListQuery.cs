using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.PriceLists.Responses;

namespace CleaningCompany.Application.CQRS.PriceLists.Queries.GetCurrent;

public record GetCurrentPriceListQuery() : IQuery<GetPriceListResponse>;
