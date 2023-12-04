using AutoMapper;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.Regions.Responses;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.Regions.Queries.GetAll;

public sealed class GetAllRegionsQueryHandler : IQueryHandler<GetAllRegionsQuery, IEnumerable<GetAllRegionsResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRegionsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<GetAllRegionsResponse>>> Handle(
        GetAllRegionsQuery query,
        CancellationToken cancellationToken)
    {
        IEnumerable<Region> regions = await _unitOfWork.RegionRepository
            .GetAllAsync(cancellationToken);

        var regionsResponse = _mapper
            .Map<IEnumerable<GetAllRegionsResponse>>(regions);

        return Result.Success(regionsResponse);
    }
}
