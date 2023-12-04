using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Users.Commands.Register;

public record RegisterCommand(
    string Surname,
    string Name,
    string Patronymic,
    string Email,
    string UserName,
    string Password,
    string PasswordConfirm,
    Guid? RoleId = null) : ICommand;
