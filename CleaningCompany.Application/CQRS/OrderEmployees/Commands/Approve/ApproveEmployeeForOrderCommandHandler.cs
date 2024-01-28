using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.OrderAggregate.ValueObjects;
using CleaningCompany.Domain.AggregateModels.OrderEmployeeAggregate;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.Errors;
using CleaningCompany.Domain.Common.OperationResults;
using ComputerRepair.Domain.Common.Errors;
using System.Security.Claims;

namespace CleaningCompany.Application.CQRS.OrderEmployees.Commands.Approve;

public sealed class ApproveEmployeeForOrderCommandHandler
    : ICommandHandler<ApproveEmployeeForOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public ApproveEmployeeForOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        ApproveEmployeeForOrderCommand command, 
        CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        Claim? userWhoApprovedIdClaim = command.EmployeeWhoApprovedId.FindFirst(ClaimTypes.NameIdentifier);

        if (userWhoApprovedIdClaim == null)
        {
            errors.Add(Errors.User.CannotBeIdentified());
        }

        Guid userWhoApprovedId = Guid.Parse(userWhoApprovedIdClaim.Value);

        bool userWhoApprovedIsExist = await _unitOfWork.UserRepository
            .IsExistByIdAsync(UserId.Create(userWhoApprovedId));

        if (!userWhoApprovedIsExist)
        {
            errors.Add(Errors.User
                .NotFoundById(userWhoApprovedId.ToString()));
        }

        bool userWhoPerformedIsExist = await _unitOfWork.UserRepository
            .IsExistByIdAsync(UserId.Create(command.EmployeeWhoPerformedId));

        if (!userWhoPerformedIsExist)
        {
            errors.Add(Errors.User
                .NotFoundById(command.EmployeeWhoPerformedId.ToString()));
        }

        var orderEmployee = OrderEmployee.Create(
            UserId.Create(userWhoApprovedId),
            UserId.Create(command.EmployeeWhoPerformedId),
            OrderId.Create(command.OrderId));

        await _unitOfWork.OrderEmployeeRepository
            .CreateAsync(orderEmployee, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
