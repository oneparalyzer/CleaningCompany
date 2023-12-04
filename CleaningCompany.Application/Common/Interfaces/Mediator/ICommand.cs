using CleaningCompany.Domain.Common.OperationResults;
using MediatR;

namespace CleaningCompany.Application.Common.Interfaces.Mediator;

public interface ICommand : IRequest<Result>
{
}
