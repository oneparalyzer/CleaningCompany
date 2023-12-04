using CleaningCompany.Domain.Common.OperationResults;
using MediatR;

namespace CleaningCompany.Application.Common.Interfaces.Mediator;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}
