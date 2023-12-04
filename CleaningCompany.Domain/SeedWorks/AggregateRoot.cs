using CleaningCompany.Domain.Common.ValueObjects;

namespace CleaningCompany.Domain.SeedWorks;

public abstract class AggregateRoot<TId> : Entity<TId>, IHasDomainEvents
    where TId : Id
{
    private List<IDomainEvent> _domainEvents = new();

    protected AggregateRoot(TId id) : base(id)
    {
    }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
