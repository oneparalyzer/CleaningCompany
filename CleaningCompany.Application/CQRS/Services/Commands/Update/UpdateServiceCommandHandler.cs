using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.RegionAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.Errors;
using ComputerRepair.Domain.Common.Errors;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;

namespace CleaningCompany.Application.CQRS.Services.Commands.Update;

public sealed class UpdateServiceCommandHandler : ICommandHandler<UpdateServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        bool serviceIsExistingByTitle = await _unitOfWork.ServiceRepository
            .IsExistingByTitleAsync(command.NewTitle, cancellationToken);

        if (serviceIsExistingByTitle)
        {
            errors.Add(Errors.Service
                .AlreadyExistByTitle(command.NewTitle));
        }

        Service? serviceById = await _unitOfWork.ServiceRepository
            .GetByIdAsync(ServiceId.Create(command.ServiceId), cancellationToken);

        if (serviceById is null)
        {
            errors.Add(Errors.Service
                .NotFoundById(command.ServiceId.ToString()));
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        serviceById.Update(command.NewTitle);

        await _unitOfWork.ServiceRepository.UpdateAsync(serviceById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
