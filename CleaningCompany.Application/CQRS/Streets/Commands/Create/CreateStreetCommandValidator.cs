using FluentValidation;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Create;

public sealed class CreateStreetCommandValidator : AbstractValidator<CreateStreetCommand>
{
    public CreateStreetCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.CityId).NotEqual(Guid.Empty);
    }
}
