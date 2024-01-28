using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class OrderEmployeeRepository : IOrderEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public OrderEmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(OrderEmployee orderEmployee, CancellationToken cancellationToken = default)
    {
        await _context.OrderEmployees.AddAsync(orderEmployee, cancellationToken);
    }

    public async Task<List<OrderEmployee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.OrderEmployees.ToListAsync(cancellationToken);
    }
}
