using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class RegionRepository : IRegionRepository
{
    private readonly ApplicationDbContext _context;

    public RegionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Region region, CancellationToken cancellationToken = default)
    {
        await _context.Regions.AddAsync(region, cancellationToken);
    }

    public async Task<IEnumerable<Region>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Regions.ToListAsync(cancellationToken);
    }

    public async Task<Region?> GetByIdAsync(RegionId regionId, CancellationToken cancellationToken = default)
    {
        return await _context.Regions
            .FirstOrDefaultAsync(x =>
                x.Id == regionId,
                cancellationToken);
    }

    public async Task<bool> IsExistingByIdAsync(RegionId regionId, CancellationToken cancellationToken = default)
    {
        return await _context.Regions
            .AnyAsync(x =>
                x.Id == regionId,
                cancellationToken);
    }

    public async Task<bool> IsExistingByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Regions
            .AnyAsync(x =>
                x.Title == title,
                cancellationToken);
    }

    public async Task RemoveAsync(Region region, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Regions.Remove(region);
        }, cancellationToken);
    }

    public async Task UpdateAsync(Region region, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Regions.Update(region);
        }, cancellationToken);
    }
}
