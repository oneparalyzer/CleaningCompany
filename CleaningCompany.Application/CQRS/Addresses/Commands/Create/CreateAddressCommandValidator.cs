using FluentValidation;

namespace CleaningCompany.Application.CQRS.Addresses.Commands.Create;

public sealed class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(x => x.Apartments).MinimumLength(1);
        RuleFor(x => x.Home).MinimumLength(1);
        RuleFor(x => x.StreetId).NotEqual(Guid.Empty);
    }
}
