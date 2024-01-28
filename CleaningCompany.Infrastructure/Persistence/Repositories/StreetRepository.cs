using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class StreetRepository : IStreetRepository
{
    private readonly ApplicationDbContext _context;

    public StreetRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Street street, CancellationToken cancellationToken = default)
    {
        await _context.Streets.AddAsync(street, cancellationToken);
    }

    public async Task<List<Street>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Streets
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Street>> GetAllByCityIdAsync(CityId cityId, CancellationToken cancellationToken = default)
    {
        return await _context.Streets
            .Where(x => x.CityId == cityId)
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);
    }

    public async Task<Street?> GetByIdAsync(StreetId streetId, CancellationToken cancellationToken = default)
    {
        return await _context.Streets
            .FirstOrDefaultAsync(x => 
                x.Id == streetId, 
                cancellationToken);
    }

    public async Task<bool> IsExistingByIdAsync(StreetId streetId, CancellationToken cancellationToken = default)
    {
        return await _context.Streets
            .AnyAsync(x => 
                x.Id == streetId,
                cancellationToken);
    }

    public async Task<bool> IsExistingByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Streets
            .AnyAsync(x =>
                x.Title == title,
                cancellationToken);
    }

    public async Task RemoveAsync(Street street, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Streets.Remove(street);
        }, cancellationToken);
    }

    public async Task UpdateAsync(Street street, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Streets.Update(street);
        }, cancellationToken);
    }
}
