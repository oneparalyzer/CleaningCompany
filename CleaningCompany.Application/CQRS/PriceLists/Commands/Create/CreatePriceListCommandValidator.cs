using FluentValidation;

namespace CleaningCompany.Application.CQRS.PriceLists.Commands.Create;

public sealed class CreatePriceListCommandValidator : AbstractValidator<CreatePriceListCommand>
{
    public CreatePriceListCommandValidator()
    {
        
    }
}
