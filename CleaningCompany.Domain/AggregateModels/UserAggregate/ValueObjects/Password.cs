using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;

public sealed class Password : ValueObject
{
    private Password(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Password Create(string value)
    {
        return new Password(value);
    }
}
