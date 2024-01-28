using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IServiceRepository
{
    Task CreateAsync(
        Service service, 
        CancellationToken cancellationToken = default);

    Task RemoveAsync(
        Service service, 
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Service service, 
        CancellationToken cancellationToken = default);

    Task<List<Service>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<bool> IsExistingByIdAsync(
        ServiceId serviceId, 
        CancellationToken cancellationToken= default);
    Task<bool> IsExistingByTitleAsync(
        string title, 
        CancellationToken cancellationToken = default);

    Task<Service?> GetByIdAsync(
        ServiceId serviceId, 
        CancellationToken cancellationToken = default);

    Task<List<Service>> GetAllByIdsAsync(
        List<ServiceId> serviceIds,
        CancellationToken cancellationToken = default);
}
