using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class PriceListRepository : IPriceListRepository
{
    private readonly ApplicationDbContext _context;

    public PriceListRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(PriceList priceList, CancellationToken cancellationToken = default)
    {
        await _context.PriceLists.AddAsync(priceList, cancellationToken);
    }

    public async Task<List<PriceList>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.PriceLists
            .ToListAsync(cancellationToken);
    }

    public async Task<PriceList?> GetByIdAsync(PriceListId priceListId, CancellationToken cancellationToken = default)
    {
        return await _context.PriceLists
            .Include(x => x.Positions)
            .FirstOrDefaultAsync(x =>
                x.Id == priceListId,
                cancellationToken);
    }

    public async Task<PriceListId?> GetIdOfCurrentAsync(CancellationToken cancellationToken = default)
    {
        return await _context.PriceLists
            .OrderBy(x => x.CreatedDate)
            .Select(x => x.Id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PriceListPosition?> GetPositionByIdAsync(PriceListPositionId positionId, CancellationToken cancellationToken = default)
    {
        return await _context.PriceListPositions
            .FirstOrDefaultAsync(x =>
                x.Id == positionId,
                cancellationToken);
    }

    public async Task<bool> IsExistingByIdAsync(PriceListId priceListId, CancellationToken cancellationToken = default)
    {
        return await _context.PriceLists
            .FirstOrDefaultAsync(x =>
                x.Id == priceListId,
                cancellationToken) is not null;
    }

    public async Task RemoveAsync(PriceList priceList, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.PriceLists.Remove(priceList);
        }, cancellationToken);
    }

    public async Task UpdateAsync(PriceList priceList, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.PriceLists.Update(priceList);
        }, cancellationToken);
    }
}
