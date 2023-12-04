using FluentValidation;

namespace CleaningCompany.Application.CQRS.Services.Commands.Create;

public sealed class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(x => x.Title).MaximumLength(50).MinimumLength(5);
    }
}
