using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.Common.ValueObjects;

public abstract class Id : ValueObject
{
    protected Id(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
