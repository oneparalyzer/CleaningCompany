using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Contracts.Addresses.Responses;

namespace CleaningCompany.Application.CQRS.Addresses.Queries.GetAll;

public record GetAllAddressesQuery() : IQuery<List<GetAllAddressesResponse>>;
