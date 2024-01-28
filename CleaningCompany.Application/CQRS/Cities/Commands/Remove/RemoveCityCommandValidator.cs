using FluentValidation;

namespace CleaningCompany.Application.CQRS.Cities.Commands.Remove;

public sealed class RemoveCityCommandValidator : AbstractValidator<RemoveCityCommand>
{
    public RemoveCityCommandValidator()
    {
        RuleFor(x => x.CityId).NotEqual(Guid.Empty);
    }
}
