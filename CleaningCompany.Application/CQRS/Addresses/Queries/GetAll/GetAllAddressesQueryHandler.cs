using AutoMapper;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.Addresses.Responses;
using CleaningCompany.Domain.AggregateModels.AddressAggregate;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.Addresses.Queries.GetAll;

public sealed class GetAllAddressesQueryHandler
    : IQueryHandler<GetAllAddressesQuery, List<GetAllAddressesResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAddressesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllAddressesResponse>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        List<Address> addresses = await _unitOfWork.AddressRepository
            .GetAllAsync(cancellationToken);

        var addressesResponse = _mapper
            .Map<List<GetAllAddressesResponse>>(addresses);

        return Result.Success(addressesResponse);
    }
}
