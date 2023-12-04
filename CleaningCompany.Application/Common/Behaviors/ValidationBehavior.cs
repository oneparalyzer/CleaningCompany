using MediatR;
using FluentValidation;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.Errors;

namespace CleaningCompany.Application.Common.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator
            .ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return (dynamic)Result.Failure(ConvertToErrors(validationResult.ToDictionary()));
        }

        return await next();
    }

    private List<Error> ConvertToErrors(IDictionary<string, string[]> validationErrors)
    {
        return validationErrors
        .SelectMany(fieldErrors => fieldErrors.Value, (fieldErrors, fieldError) => new Error(
            $"{fieldErrors.Key}.ValidationError",
            fieldError,
            fieldErrors.Key))
        .ToList();
    }
}
