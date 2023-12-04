using CleaningCompany.Domain.AggregateModels.AddressAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.AddressAggregate;

public sealed class Address : AggregateRoot<AddressId>
{
    private Address(AddressId id, string home, string? building, string apartments, string? room, StreetId streetId) : base(id)
    {
        Home = home;
        Building = building;
        Apartments = apartments;
        Room = room;
        StreetId = streetId;
    }

    public string Home { get; private set; }
    public string? Building { get; private set; }
    public string Apartments { get; private set; }
    public string? Room { get; private set; }
    public StreetId StreetId { get; private set; }

    public static Address Create(string home, string? building, string apartments, string? room, StreetId streetId)
    {
        return new Address(AddressId.Create(), home, building, apartments, room, streetId);
    }
}
