using FluentValidation;

namespace CleaningCompany.Application.CQRS.OrderEmployees.Commands.Approve;

public sealed class ApproveEmployeeForOrderCommandValidator 
    : AbstractValidator<ApproveEmployeeForOrderCommand>
{
    public ApproveEmployeeForOrderCommandValidator()
    {
        RuleFor(x => x.EmployeeWhoPerformedId).NotEqual(Guid.Empty);
        RuleFor(x => x.OrderId).NotEqual(Guid.Empty);
    }
}
