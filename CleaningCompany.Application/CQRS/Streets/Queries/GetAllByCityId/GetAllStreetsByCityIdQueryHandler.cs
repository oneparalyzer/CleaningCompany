using AutoMapper;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.Streets.Responses;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.Streets.Queries.GetAllByCityId;

public sealed class GetAllStreetsByCityIdQueryHandler 
    : IQueryHandler<GetAllStreetsByCityIdQuery, List<GetAllStreetsResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStreetsByCityIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<GetAllStreetsResponse>>> Handle(
        GetAllStreetsByCityIdQuery query, 
        CancellationToken cancellationToken)
    {
        List<Street> streets = await _unitOfWork.StreetRepository
            .GetAllByCityIdAsync(
                CityId.Create(query.CityId), 
                cancellationToken);

        var streetsResponse = _mapper
            .Map<List<GetAllStreetsResponse>>(streets);

        return Result.Success(streetsResponse);
    }
}
