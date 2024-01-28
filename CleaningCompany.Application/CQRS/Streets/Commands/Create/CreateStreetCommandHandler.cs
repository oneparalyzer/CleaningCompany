using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.CityAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte;
using CleaningCompany.Domain.Common.Errors;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Create;

public sealed class CreateStreetCommandHandler : ICommandHandler<CreateStreetCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStreetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        CreateStreetCommand command, 
        CancellationToken cancellationToken)
    {
        List<Error> errors = await ValidateForExisting(command, cancellationToken);

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        var street = Street.Create(
            command.Title,
            CityId.Create(command.CityId));

        await _unitOfWork.StreetRepository.CreateAsync(street, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private async Task<List<Error>> ValidateForExisting(
        CreateStreetCommand command,
        CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        bool cityIsExistingById = await _unitOfWork.CityRepository
            .IsExistingByIdAsync(CityId.Create(command.CityId));

        if (cityIsExistingById)
        {
            errors.Add(Errors.City
                .NotFoundById(command.CityId.ToString()));
        }

        bool streetIsExistingByTitle = await _unitOfWork.StreetRepository
            .IsExistingByTitleAsync(command.Title, cancellationToken);

        if (streetIsExistingByTitle)
        {
            errors.Add(Errors.Street
                .AlreadyExistByTitle(command.Title));
        }

        return errors;
    }
}
