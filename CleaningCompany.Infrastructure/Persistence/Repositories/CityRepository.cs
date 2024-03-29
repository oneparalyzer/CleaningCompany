﻿using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;

    public CityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(City city, CancellationToken cancellationToken = default)
    {
        await _context.Cities.AddAsync(city, cancellationToken);
    }

    public async Task<List<City>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Cities.ToListAsync(cancellationToken);
    }

    public async Task<List<City>> GetAllByRegionIdAsync(RegionId regionId, CancellationToken cancellationToken = default)
    {
        return await _context.Cities
            .Where(x => 
                x.RegionId == regionId)
            .ToListAsync(cancellationToken);
    }

    public async Task<City?> GetByIdAsync(CityId cityId, CancellationToken cancellationToken = default)
    {
        return await _context.Cities
            .FirstOrDefaultAsync(x => 
                x.RegionId == cityId,
                cancellationToken);
    }

    public async Task<bool> IsExistingByIdAsync(CityId cityId, CancellationToken cancellationToken = default)
    {
        return await _context.Cities
            .AnyAsync(x =>
                x.RegionId == cityId,
                cancellationToken);
    }

    public async Task<bool> IsExistingByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await _context.Cities
            .AnyAsync(x =>
                x.Title == title,
                cancellationToken);
    }

    public async Task RemoveAsync(City city, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Cities.Remove(city);
        }, cancellationToken);
    }

    public async Task UpdateAsync(City city, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Cities.Update(city);
        }, cancellationToken);
    }
}
