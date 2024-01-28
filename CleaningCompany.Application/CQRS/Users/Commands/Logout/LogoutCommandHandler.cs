using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.Common.OperationResults;

namespace CleaningCompany.Application.CQRS.Users.Commands.Logout;

public sealed class LogoutCommandHandler : ICommandHandler<LogoutCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public LogoutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(LogoutCommand command, CancellationToken cancellationToken)
    {
        await _unitOfWork.UserRepository.LogoutAsync();

        return Result.Success();
    }
}
