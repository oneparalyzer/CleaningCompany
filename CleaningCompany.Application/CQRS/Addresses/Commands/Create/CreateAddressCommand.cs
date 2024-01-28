using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Addresses.Commands.Create;

public record CreateAddressCommand(
    string Home, 
    string? Building, 
    string Apartments, 
    string? Room, 
    Guid StreetId) : ICommand;
