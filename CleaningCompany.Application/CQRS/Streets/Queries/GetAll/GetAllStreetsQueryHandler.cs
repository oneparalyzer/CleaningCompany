using AutoMapper;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.Streets.Responses;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.Streets.Queries.GetAll;

public sealed class GetAllStreetsQueryHandler
    : IQueryHandler<GetAllStreetsQuery, List<GetAllStreetsResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStreetsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<GetAllStreetsResponse>>> Handle(
        GetAllStreetsQuery query, 
        CancellationToken cancellationToken)
    {
        List<Street> streets = await _unitOfWork.StreetRepository
            .GetAllAsync(cancellationToken);

        var streetsResponse = _mapper
            .Map<List<GetAllStreetsResponse>>(streets);

        return Result.Success(streetsResponse);
    }
}
