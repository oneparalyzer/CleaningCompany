using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Remove;

public sealed class RemoveStreetCommandHandler : ICommandHandler<RemoveStreetCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveStreetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        RemoveStreetCommand command, 
        CancellationToken cancellationToken)
    {
        var streetById = await _unitOfWork.StreetRepository
            .GetByIdAsync(StreetId.Create(command.StreetId), cancellationToken);

        if (streetById is null)
        {
            return Result.Failure(Errors.Street
                .NotFoundById(command.StreetId.ToString())
                .ToList());
        }

        await _unitOfWork.StreetRepository.RemoveAsync(streetById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
