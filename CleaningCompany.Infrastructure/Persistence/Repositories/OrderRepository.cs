using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.OrderAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .Include(x => x.Statuses)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(OrderId orderId, CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .Include(x => x.Statuses)
            .Include(x => x.Positions)
            .FirstOrDefaultAsync(x =>
                x.Id == orderId);
    }

    public async Task<bool> IsExistingByIdAsync(OrderId orderId, CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .AnyAsync(x =>
                x.Id == orderId);
    }

    public async Task RemoveAsync(Order order, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Orders.Remove(order);
        }, cancellationToken);
    }

    public async Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            _context.Orders.Update(order);
        }, cancellationToken);
    }
}
