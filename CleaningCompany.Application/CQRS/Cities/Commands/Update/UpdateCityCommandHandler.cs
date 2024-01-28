using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.Errors;
using ComputerRepair.Domain.Common.Errors;
using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Update;

public sealed class UpdateCityCommandHandler 
    : ICommandHandler<UpdateCityCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateCityCommand command, 
        CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        bool cityIsExistingByTitle = await _unitOfWork.CityRepository
            .IsExistingByTitleAsync(command.NewTitle, cancellationToken);

        if (cityIsExistingByTitle)
        {
            errors.Add(Errors.City
                .AlreadyExistByTitle(command.NewTitle));
        }

        City? cityById = await _unitOfWork.CityRepository
            .GetByIdAsync(CityId.Create(command.CityId), cancellationToken);

        if (cityById is null)
        {
            errors.Add(Errors.City
                .NotFoundById(command.CityId.ToString()));
        }

        Region? regionById = await _unitOfWork.RegionRepository
            .GetByIdAsync(RegionId.Create(command.NewRegionId), cancellationToken);

        if (regionById is null)
        {
            errors.Add(Errors.Region
                .NotFoundById(command.NewRegionId.ToString()));
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        cityById.Update(command.NewTitle, RegionId.Create(command.NewRegionId));

        await _unitOfWork.CityRepository.UpdateAsync(cityById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
