using FluentValidation;

namespace CleaningCompany.Application.CQRS.Users.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Surname)
            .MinimumLength(2)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.Name)
            .MinimumLength(2)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.Patronymic)
            .MinimumLength(2)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.UserName)
            .MinimumLength(2)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Пароль обязателен для заполнения")
            //.Equal(x => x.PasswordConfirm)
            .WithMessage("Пароли должны совпадать");

        //RuleFor(x => x.PasswordConfirm)
        //    .NotEmpty()
        //    .WithMessage("Подтверждение пароля обязательно для заполнения");
    }
}
