using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.CityAggregate;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.Errors;
using ComputerRepair.Domain.Common.Errors;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Create;

public sealed class CreateCityCommandHandler : ICommandHandler<CreateCityCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCityCommand command, CancellationToken cancellationToken)
    {
        List<Error> errors = await ValidateForExisting(command, cancellationToken);

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        var city = City.Create(
            command.Title,
            RegionId.Create(command.RegionId));

        await _unitOfWork.CityRepository.CreateAsync(city, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private async Task<List<Error>> ValidateForExisting(
        CreateCityCommand command,
        CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        bool regionIsExistingById = await _unitOfWork.RegionRepository
            .IsExistingByIdAsync(RegionId.Create(command.RegionId));

        if (regionIsExistingById)
        {
            errors.Add(Errors.Region
                .NotFoundById(command.RegionId.ToString()));
        }

        bool cityIsExistingByTitle = await _unitOfWork.CityRepository
            .IsExistingByTitleAsync(command.Title, cancellationToken);

        if (cityIsExistingByTitle)
        {
            errors.Add(Errors.City
                .AlreadyExistByTitle(command.Title));
        }

        return errors;
    }
}
