using FluentValidation;

namespace CleaningCompany.Application.CQRS.Streets.Commands.Update;

public sealed class UpdateStreetCommandValidator : AbstractValidator<UpdateStreetCommand>
{
    public UpdateStreetCommandValidator()
    {
        RuleFor(x => x.StreetId).NotEqual(Guid.Empty);
        RuleFor(x => x.NewTitle).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.NewCityId).NotEqual(Guid.Empty);
    }
}
