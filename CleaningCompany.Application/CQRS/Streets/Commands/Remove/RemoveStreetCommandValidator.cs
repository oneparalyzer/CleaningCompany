using FluentValidation;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Remove;

public sealed class RemoveStreetCommandValidator : AbstractValidator<RemoveStreetCommand>
{
    public RemoveStreetCommandValidator()
    {
        RuleFor(x => x.StreetId).NotEqual(Guid.Empty);
    }
}
