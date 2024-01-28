using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.Entities;
using CleaningCompany.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.Errors;
using System.Security.Claims;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.PriceLists.Commands.Create;

public sealed class CreatePriceListCommandHandler : ICommandHandler<CreatePriceListCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePriceListCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreatePriceListCommand command, CancellationToken cancellationToken)
    {
        Result<PriceList> createPriceListResult = 
            CreatePriceListFromCommand(command);

        if (!createPriceListResult.IsSuccess)
        {
            return createPriceListResult;
        }

        PriceList priceList = createPriceListResult.Value;

        await _unitOfWork.PriceListRepository.CreateAsync(priceList, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private Result<PriceList> CreatePriceListFromCommand(CreatePriceListCommand command)
    {
        Claim? userIdClaim = command.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
        {
            return Result.Failure<PriceList>(Errors.User
                .CannotBeIdentified()
                .ToList());
        }

        Guid employeeId = Guid.Parse(userIdClaim.Value);


        List<PriceListPosition> positions = command.Positions
            .Select(position => PriceListPosition.Create(
                ServiceId.Create(position.ServiceId),
                Price.Create(position.Price)))
            .ToList();

        return PriceList.Create(UserId.Create(employeeId), positions);
    }
}
