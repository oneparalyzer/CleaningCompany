using FluentValidation;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Create;

public sealed class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(x => x.Title).MinimumLength(5).MaximumLength(50);
    }
}
