using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.AddressAggregate;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Address address, CancellationToken cancellationToken = default)
    {
        await _context.Addresses.AddAsync(address, cancellationToken);
    }

    public async Task<List<Address>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Addresses.ToListAsync(cancellationToken);
    }

    public async Task RemoveAsync(Address address, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Addresses.Remove(address);
        }, cancellationToken);
    }

    public async Task UpdateAsync(Address address, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Addresses.Update(address);
        }, cancellationToken);
    }
}
