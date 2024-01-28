using FluentValidation;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Update;

public sealed class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
{
    public UpdateRegionCommandValidator()
    {
        RuleFor(x => x.NewTitle).MinimumLength(5).MaximumLength(50);
        RuleFor(x => x.RegionId).NotEqual(Guid.Empty);
    }
}
