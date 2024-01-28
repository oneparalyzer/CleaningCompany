using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Update;

public sealed class UpdateRegionCommandHandler : ICommandHandler<UpdateRegionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRegionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateRegionCommand command, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        bool regionIsExistingByTitle = await _unitOfWork.RegionRepository
            .IsExistingByTitleAsync(command.NewTitle, cancellationToken);

        if (regionIsExistingByTitle)
        {
            errors.Add(Errors.Region
                .AlreadyExistByTitle(command.NewTitle));
        }

        Region? regionById = await _unitOfWork.RegionRepository
            .GetByIdAsync(RegionId.Create(command.RegionId), cancellationToken);

        if (regionById is null)
        {
            errors.Add(Errors.Region
                .NotFoundById(command.RegionId.ToString()));
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        regionById.Update(command.NewTitle);

        await _unitOfWork.RegionRepository.UpdateAsync(regionById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
