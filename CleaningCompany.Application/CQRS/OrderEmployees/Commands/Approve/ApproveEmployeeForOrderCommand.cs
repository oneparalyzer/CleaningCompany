using CleaningCompany.Application.Common.Interfaces.Mediator;
using System.Security.Claims;

namespace CleaningCompany.Application.CQRS.OrderEmployees.Commands.Approve;

public record ApproveEmployeeForOrderCommand(
    ClaimsPrincipal EmployeeWhoApprovedId,
    Guid EmployeeWhoPerformedId,
    Guid OrderId) : ICommand;
