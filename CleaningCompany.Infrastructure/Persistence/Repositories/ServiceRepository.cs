using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Service service, CancellationToken cancellationToken = default)
    {
        await _context.Services.AddAsync(service, cancellationToken);
    }

    public async Task<List<Service>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Services.OrderBy(x => x.Title).ToListAsync(cancellationToken);
    }

    public async Task<List<Service>> GetAllByIdsAsync(
        List<ServiceId> serviceIds, 
        CancellationToken cancellationToken = default)
    {
        return await _context.Services
            .Where(x => serviceIds.Contains(x.Id))
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);

    }

    public async Task<Service?> GetByIdAsync(ServiceId serviceId, CancellationToken cancellationToken = default)
    {
        return await _context.Services
            .FirstOrDefaultAsync(x =>
                x.Id == serviceId);
    }

    public async Task<bool> IsExistingByIdAsync(ServiceId serviceId, CancellationToken cancellationToken = default)
    {
        return await _context.Services
            .AnyAsync(x =>
                x.Id == serviceId,
                cancellationToken);
    }

    public async Task<bool> IsExistingByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Services
            .AnyAsync(x =>
                x.Title == title,
                cancellationToken);
    }

    public async Task RemoveAsync(Service service, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Services.Remove(service);
        }, cancellationToken);
    }

    public async Task UpdateAsync(Service service, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Services.Update(service);
        }, cancellationToken);
    }
}
