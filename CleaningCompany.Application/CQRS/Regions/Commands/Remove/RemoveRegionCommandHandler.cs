using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Remove;

public sealed class RemoveRegionCommandHandler : ICommandHandler<RemoveRegionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveRegionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveRegionCommand command, CancellationToken cancellationToken)
    {
        Region? regionById = await _unitOfWork.RegionRepository
            .GetByIdAsync(RegionId.Create(command.RegionId), cancellationToken);

        if (regionById is null)
        {
            return Result.Failure(Errors.Region
                .NotFoundById(command.RegionId.ToString())
                .ToList());
        }

        await _unitOfWork.RegionRepository.RemoveAsync(regionById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
