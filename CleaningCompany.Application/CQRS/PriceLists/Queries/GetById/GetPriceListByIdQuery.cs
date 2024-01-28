using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.PriceLists.Responses;

namespace CleaningCompany.Application.CQRS.PriceLists.Queries.GetById;

public record GetPriceListByIdQuery(
    Guid PriceListId) : IQuery<GetPriceListResponse>;
