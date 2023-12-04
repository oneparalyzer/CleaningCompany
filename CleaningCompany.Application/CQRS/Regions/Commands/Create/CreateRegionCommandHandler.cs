using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.RegionAggregate;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Create;

public sealed class CreateRegionCommandHandler : ICommandHandler<CreateRegionCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateRegionCommand command, CancellationToken cancellationToken)
    {
        bool regionIsExistingByTitle = await _unitOfWork.RegionRepository
            .IsExistingByTitleAsync(command.Title);

        if (regionIsExistingByTitle)
        {
            return Result.Failure(Errors.Region
                .AlreadyExistByTitle(command.Title)
                .ToList());
        }

        var region = Region.Create(command.Title);

        await _unitOfWork.RegionRepository.CreateAsync(region, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
