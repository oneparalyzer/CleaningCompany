using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Users.Commands.Login;

public record LoginCommand(
    string UserName,
    string Password,
    bool RememberMe) : ICommand;
