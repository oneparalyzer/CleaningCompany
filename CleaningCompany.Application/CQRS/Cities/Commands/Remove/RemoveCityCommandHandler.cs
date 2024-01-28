using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Remove;

public sealed class RemoveCityCommandHandler : ICommandHandler<RemoveCityCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveCityCommand command, CancellationToken cancellationToken)
    {
        var cityById = await _unitOfWork.CityRepository
            .GetByIdAsync(CityId.Create(command.CityId), cancellationToken);

        if (cityById is null)
        {
            return Result.Failure(Errors.City
                .NotFoundById(command.CityId.ToString())
                .ToList());
        }

        await _unitOfWork.CityRepository.RemoveAsync(cityById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
