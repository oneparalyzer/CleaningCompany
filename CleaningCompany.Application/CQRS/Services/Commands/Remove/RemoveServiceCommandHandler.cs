using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Services.Commands.Remove;

public sealed class RemoveServiceCommandHandler : ICommandHandler<RemoveServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveServiceCommand command, CancellationToken cancellationToken)
    {
        Service? serviceById = await _unitOfWork.ServiceRepository
            .GetByIdAsync(ServiceId.Create(command.ServiceId), cancellationToken);

        if (serviceById is null)
        {
            return Result.Failure(Errors.Service
                .NotFoundById(command.ServiceId.ToString())
                .ToList());
        }

        await _unitOfWork.ServiceRepository.RemoveAsync(serviceById, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
