using FluentValidation;

namespace CleaningCompany.Application.CQRS.Services.Commands.Remove;

public sealed class RemoveServiceCommandValidator : AbstractValidator<RemoveServiceCommand>
{
    public RemoveServiceCommandValidator()
    {
        RuleFor(x => x.ServiceId).NotEqual(Guid.Empty);
    }
}
