using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.StreetAggreagte.ValueObjects;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;
using CleaningCompany.Domain.AggregateModels.AddressAggregate;

namespace CleaningCompany.Application.CQRS.Addresses.Commands.Create;

public sealed class CreateAddressCommandHandler : ICommandHandler<CreateAddressCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAddressCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        CreateAddressCommand command, 
        CancellationToken cancellationToken)
    {
        bool streetIsExistingByIdAsync = await _unitOfWork.StreetRepository
            .IsExistingByIdAsync(
            StreetId.Create(command.StreetId), 
            cancellationToken);

        if (streetIsExistingByIdAsync)
        {
            return Result.Failure(Errors.Street
                .NotFoundById(command.StreetId.ToString()).ToList());
        }

        var address = Address.Create(
            command.Home,
            command.Building,
            command.Apartments,
            command.Room,
            StreetId.Create(
                command.StreetId));

        await _unitOfWork.AddressRepository.CreateAsync(address, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();    
    }
}
