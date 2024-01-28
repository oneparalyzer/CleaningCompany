using FluentValidation;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Create;

public sealed class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(2).MaximumLength(50);
        RuleFor(x => x.RegionId).NotEqual(Guid.Empty);
    }
}
