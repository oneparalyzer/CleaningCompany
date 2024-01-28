using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;
using CleaningCompany.Domain.AggregateModels.ServiceAggregate;

namespace CleaningCompany.Application.CQRS.Services.Commands.Create;

public sealed class CreateServiceCommandHandler : ICommandHandler<CreateServiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        bool serviceIsExistByTitle = await _unitOfWork.ServiceRepository
            .IsExistingByTitleAsync(command.Title);

        if (serviceIsExistByTitle)
        {
            return Result.Failure(Errors.Service
                .AlreadyExistByTitle(command.Title)
                .ToList());
        }

        var service = Service.Create(command.Title);

        await _unitOfWork.ServiceRepository.CreateAsync(service, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
