using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;

public sealed class EmailAddress : ValueObject
{
    private EmailAddress(string value)
    {
        Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static EmailAddress Create(string value)
    {
        return new EmailAddress(value);
    }
}
