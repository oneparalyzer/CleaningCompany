using FluentValidation;

namespace CleaningCompany.Application.CQRS.Services.Commands.Update;

public sealed class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
{
    public UpdateServiceCommandValidator()
    {
        RuleFor(x => x.NewTitle).MaximumLength(50).MinimumLength(5);
        RuleFor(x => x.ServiceId).NotEqual(Guid.Empty);
    }
}
