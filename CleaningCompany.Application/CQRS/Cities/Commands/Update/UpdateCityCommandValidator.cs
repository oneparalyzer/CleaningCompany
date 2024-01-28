using FluentValidation;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Update;

public sealed class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(x => x.CityId).NotEqual(Guid.Empty);
        RuleFor(x => x.NewTitle).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.NewRegionId).NotEqual(Guid.Empty);
    }
}
