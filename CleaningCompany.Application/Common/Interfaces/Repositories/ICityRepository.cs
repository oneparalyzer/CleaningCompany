using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(CityId cityId, CancellationToken cancellationToken = default);
    Task CreateAsync(City city, CancellationToken cancellationToken = default);
    Task RemoveAsync(City city, CancellationToken cancellationToken = default);
    Task UpdateAsync(City city, CancellationToken cancellationToken = default);
    Task<List<City>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> IsExistingByIdAsync(CityId cityId, CancellationToken cancellationToken = default);
    Task<bool> IsExistingByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<List<City>> GetAllByRegionIdAsync(RegionId regionId, CancellationToken cancellationToken = default);
}
