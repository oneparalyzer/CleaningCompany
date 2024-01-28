using CleaningCompany.Application.Common.Interfaces.Mediator;

namespace CleaningCompany.Application.CQRS.Users.Commands.Logout;

public record LogoutCommand() : ICommand;
