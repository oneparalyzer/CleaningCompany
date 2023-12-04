using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.Errors;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Users.Commands.Login;

public sealed class LoginCommandHandler : ICommandHandler<LoginCommand>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        bool canSignIn = await _userRepository.TryPasswordSignInAsync(
            request.UserName, 
            request.Password, 
            request.RememberMe);

        if (!canSignIn)
        {
            return Result.Failure(
                Errors.User.InvalidCredentionals.ToList());
        }

        return Result.Success();
    }
}
