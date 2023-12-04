using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IRegionRepository
{
    Task CreateAsync(Region region, CancellationToken cancellationToken = default);
    Task RemoveAsync(Region region, CancellationToken cancellationToken = default);
    Task UpdateAsync(Region region, CancellationToken cancellationToken = default);
    Task<IEnumerable<Region>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> IsExistingByIdAsync(RegionId regionId, CancellationToken cancellationToken = default);
    Task<bool> IsExistingByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<Region?> GetByIdAsync(RegionId regionId, CancellationToken cancellationToken = default);
}
