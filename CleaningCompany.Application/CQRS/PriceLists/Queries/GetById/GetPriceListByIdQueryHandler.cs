using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Contracts.PriceLists.Responses;
using CleaningCompany.Domain.AggregateModels.UserAggregate;
using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.Common.Errors;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.PriceLists.Queries.GetById;

public sealed class GetPriceListByIdQueryHandler
    : IQueryHandler<GetPriceListByIdQuery, GetPriceListResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPriceListByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetPriceListResponse>> Handle(
        GetPriceListByIdQuery query, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        PriceList? priceListById = await _unitOfWork.PriceListRepository
            .GetByIdAsync(
                PriceListId.Create(query.PriceListId),
                cancellationToken);

        if (priceListById is null)
        {
            errors.Add(Errors.PriceList
                .NotFoundById(query.PriceListId.ToString()));
        }

        User? employeeById = await _unitOfWork.UserRepository
            .GetByIdAsync(priceListById.EmployeeId);

        if (employeeById is null)
        {
            errors.Add(Errors.User
                .NotFoundById(priceListById.EmployeeId.Value.ToString()));
        }

        List<ServiceId> serviceIds = priceListById.Positions
            .Select(x =>
                x.ServiceId)
            .ToList();

        List<Service> services = await _unitOfWork.ServiceRepository
            .GetAllByIdsAsync(serviceIds, cancellationToken);

        return MapToPriceListResponse(
            priceListById,
            services,
            employeeById,
            errors);
    }

    private Result<GetPriceListResponse> MapToPriceListResponse(
        PriceList priceList, 
        List<Service> services, 
        User employee, 
        List<Error> errors)
    {
        var positionsResponse = new List<GetPositionsByPriceListByIdResponse>();

        foreach (var position in priceList.Positions)
        {
            Service? serviceById = services
                .FirstOrDefault(x =>
                    x.Id == position.ServiceId);

            if (serviceById is null)
            {
                errors.Add(Errors.Service
                    .NotFoundById(position.ServiceId.ToString()));

                continue;
            }

            positionsResponse.Add(new GetPositionsByPriceListByIdResponse
            {
                PositionId = position.Id.Value,
                ServiceTitle = serviceById.Title,
                ServiceId = serviceById.Id.Value,
                Price = position.Price.Value
            });
        }

        if (errors.Any())
        {
            return Result.Failure<GetPriceListResponse>(errors);
        }

        return Result.Success(new GetPriceListResponse
        {
            PriceListId = priceList.Id.Value,
            Positions = positionsResponse,
            EmployeeName = employee.FullName.Name,
            CreatedDate = priceList.CreatedDate,
            EmployeeSurname = employee.FullName.Surname,
            EmployeePatronymic = employee.FullName.Patronymic
        });
    }
}