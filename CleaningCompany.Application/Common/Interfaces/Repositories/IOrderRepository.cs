using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderAggregate;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(OrderId orderId, CancellationToken cancellationToken = default);
    Task CreateAsync(Order order, CancellationToken cancellationToken = default);
    Task RemoveAsync(Order order, CancellationToken cancellationToken = default);
    Task UpdateAsync(Order order, CancellationToken cancellationToken = default);
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> IsExistingByIdAsync(OrderId orderId, CancellationToken cancellationToken = default);
}
