using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.Errors;
using ComputerRepair.Domain.Common.Errors;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;

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
        bool regionIsExistingByTitle = await _unitOfWork.RegionRepository
            .IsExistingByTitleAsync(command.Title, cancellationToken);

        if (regionIsExistingByTitle)
        {
            return Result.Failure(Errors.Region
                .AlreadyExistByTitle(command.Title)
                .ToList());
        }

        Region? regionById = await _unitOfWork.RegionRepository
            .GetByIdAsync(RegionId.Create(command.RegionId), cancellationToken);

        if (regionById is null)
        {
            return Result.Failure(Errors.Region
                .NotFoundById(command.RegionId.ToString())
                .ToList());
        }

        regionById.Rename(command.Title);

        await _unitOfWork.RegionRepository.UpdateAsync(regionById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
