using CleaningCompany.Domain.AggregateModels.PriceListAggregate;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IPriceListRepository
{
    Task CreateAsync(PriceList priceList, CancellationToken cancellationToken = default);
    Task RemoveAsync(PriceList priceList, CancellationToken cancellationToken = default);
    Task UpdateAsync(PriceList priceList, CancellationToken cancellationToken = default);
    Task<List<PriceList>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> IsExistingByIdAsync(PriceListId priceListId, CancellationToken cancellationToken = default);
    Task<PriceList?> GetByIdAsync(PriceListId priceListId, CancellationToken cancellationToken = default);
    Task<PriceListPosition?> GetPositionByIdAsync(PriceListPositionId positionId, CancellationToken cancellationToken = default);
    Task<PriceListId?> GetIdOfCurrentAsync(CancellationToken cancellationToken = default);
}
