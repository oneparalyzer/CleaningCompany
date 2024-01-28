using AutoMapper;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.Cities.Responses;
using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.Cities.Queries.GetAll;

public sealed class GetAllCitiesQueryHandler
    : IQueryHandler<GetAllCitiesQuery, List<GetAllCitiesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<GetAllCitiesResponse>>> Handle(
        GetAllCitiesQuery query,
        CancellationToken cancellationToken)
    {
        List<City> cities = await _unitOfWork.CityRepository
            .GetAllAsync(cancellationToken);

        var citiesResponse = _mapper
            .Map<List<GetAllCitiesResponse>>(cities);

        return Result.Success(citiesResponse);
    }
}
