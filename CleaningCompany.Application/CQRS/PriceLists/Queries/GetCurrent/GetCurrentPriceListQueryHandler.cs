using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Contracts.PriceLists.Responses;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using MediatR;
using CleaningCompany.Application.CQRS.PriceLists.Queries.GetById;

namespace CleaningCompany.Application.CQRS.PriceLists.Queries.GetCurrent;

public sealed class GetCurrentPriceListQueryHandler 
    : IQueryHandler<GetCurrentPriceListQuery, GetPriceListResponse>
{
    private readonly ISender _sender;
    private readonly IUnitOfWork _unitOfWork;

    public GetCurrentPriceListQueryHandler(IUnitOfWork unitOfWork, ISender sender)
    {
        _unitOfWork = unitOfWork;
        _sender = sender;
    }

    public async Task<Result<GetPriceListResponse>> Handle(GetCurrentPriceListQuery request, CancellationToken cancellationToken)
    {
        PriceListId? currentPriceListId = await _unitOfWork.PriceListRepository
            .GetIdOfCurrentAsync(cancellationToken);

        if (currentPriceListId is null)
        {
            throw new ArgumentNullException(nameof(currentPriceListId));
        }

        return await _sender
            .Send(new GetPriceListByIdQuery(currentPriceListId.Value)); 
    }
}
