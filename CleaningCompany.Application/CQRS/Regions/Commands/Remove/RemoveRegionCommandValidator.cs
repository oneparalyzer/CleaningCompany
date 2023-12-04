using FluentValidation;

namespace CleaningCompany.Application.CQRS.Regions.Commands.Remove;

public sealed class RemoveRegionCommandValidator : AbstractValidator<RemoveRegionCommand>
{
    public RemoveRegionCommandValidator()
    {
        RuleFor(x => x.RegionId).NotEqual(Guid.Empty);
    }
}
