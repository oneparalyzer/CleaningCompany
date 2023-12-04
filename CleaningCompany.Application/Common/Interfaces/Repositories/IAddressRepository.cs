using CleaningCompany.Domain.AggregateModels.AddressAggregate;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IAddressRepository
{
    Task CreateAsync(Address address, CancellationToken cancellationToken = default);
    Task RemoveAsync(Address address, CancellationToken cancellationToken = default);
    Task UpdateAsync(Address address, CancellationToken cancellationToken = default);
    Task<IEnumerable<Address>> GetAllAsync(CancellationToken cancellationToken = default);
}
