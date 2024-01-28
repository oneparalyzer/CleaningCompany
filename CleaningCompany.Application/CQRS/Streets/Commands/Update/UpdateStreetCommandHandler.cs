using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;
using CleaningCompany.Domain.Common.Errors;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Update;

public sealed class UpdateStreetCommandHandler : ICommandHandler<UpdateStreetCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStreetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateStreetCommand command, 
        CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        bool streetIsExistingByTitle = await _unitOfWork.StreetRepository
            .IsExistingByTitleAsync(command.NewTitle, cancellationToken);

        if (streetIsExistingByTitle)
        {
            errors.Add(Errors.Street
                .AlreadyExistByTitle(command.NewTitle));
        }

        Street? streetById = await _unitOfWork.StreetRepository
            .GetByIdAsync(StreetId.Create(command.StreetId), cancellationToken);

        if (streetById is null)
        {
            errors.Add(Errors.Street
                .NotFoundById(command.StreetId.ToString()));
        }

        City? cityById = await _unitOfWork.CityRepository
            .GetByIdAsync(CityId.Create(command.NewCityId), cancellationToken);

        if (cityById is null)
        {
            errors.Add(Errors.City
                .NotFoundById(command.NewCityId.ToString()));
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        streetById.Update(command.NewTitle, CityId.Create(command.NewCityId));

        await _unitOfWork.CityRepository.UpdateAsync(cityById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
