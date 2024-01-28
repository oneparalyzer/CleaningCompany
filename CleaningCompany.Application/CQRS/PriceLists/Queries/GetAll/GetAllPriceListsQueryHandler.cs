using AutoMapper;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.PriceLists.Responses;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.PriceLists.Queries.GetAll;

public sealed class GetAllPriceListsQueryHandler
    : IQueryHandler<GetAllPriceListsQuery, List<GetAllPriceListsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllPriceListsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllPriceListsResponse>>> Handle(GetAllPriceListsQuery query, CancellationToken cancellationToken)
    {
        List<PriceList> priceLists = await _unitOfWork.PriceListRepository
            .GetAllAsync(cancellationToken);

        var priceListsResponse = _mapper
            .Map<List<GetAllPriceListsResponse>>(priceLists);

        return Result.Success(priceListsResponse);
    }
}
