using AutoMapper;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.Services.Responses;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.Services.Queries;

public sealed class GetAllServicesQueryHandler : IQueryHandler<GetAllServicesQuery, IEnumerable<GetAllServicesResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllServicesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<GetAllServicesResponse>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Service> services = await _unitOfWork.ServiceRepository
            .GetAllAsync(cancellationToken);

        var servicesResponse = _mapper
            .Map<IEnumerable<GetAllServicesResponse>>(services);

        return Result.Success(servicesResponse);
    }
}
