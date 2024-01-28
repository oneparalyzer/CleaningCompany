using CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IOrderEmployeeRepository
{
    Task CreateAsync(OrderEmployee orderEmployee, CancellationToken cancellationToken = default);
    
    Task<List<OrderEmployee>> GetAllAsync(CancellationToken cancellationToken = default);
}
