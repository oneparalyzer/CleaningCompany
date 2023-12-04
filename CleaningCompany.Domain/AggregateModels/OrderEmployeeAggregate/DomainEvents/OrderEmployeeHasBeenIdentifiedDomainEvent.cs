using CleaningCompany.Domain.AggregateModels.OrderAggregate.Entities;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate.DomainEvents;

public record class OrderEmployeeHasBeenIdentifiedDomainEvent(
    OrderEmployee OrderEmployee) : IDomainEvent;
