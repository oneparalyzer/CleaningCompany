using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Price Create(decimal value)
    {
        return new Price(value);
    }
}
