using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IStreetRepository
{
    Task CreateAsync(Street street, CancellationToken cancellationToken = default);
    Task RemoveAsync(Street street, CancellationToken cancellationToken = default);
    Task UpdateAsync(Street street, CancellationToken cancellationToken = default);
    Task<List<Street>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<Street>> GetAllByCityIdAsync(CityId cityId, CancellationToken cancellationToken = default);
    Task<bool> IsExistingByIdAsync(StreetId streetId, CancellationToken cancellationToken = default);
    Task<bool> IsExistingByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<Street?> GetByIdAsync(StreetId streetId, CancellationToken cancellationToken = default);
}
