using CleaningCompany.Application.Common.Interfaces.Mediator;
using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.UserAggregate;
using CleaningCompany.Domain.AggregateModels.UserAggregate.Enums;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.Errors;
using CleaningCompany.Domain.Common.OperationResults;
using CleaningCompany.Domain.Common.ValueObjects;
using CleaningCompany.Domain.SeedWorks;
using ComputerRepair.Domain.Common.Errors;

namespace CleaningCompany.Application.CQRS.Users.Commands.Register;

public sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        await CheckExistenceByEmail(command, errors);

        await CheckExistenceByUserName(command, errors);

        var role = GetRole(command, errors);

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        var user = CreateUser(command, role);

        await _unitOfWork.UserRepository.CreateAndSaveAsync(user);

        return Result.Success();
    }

    private async Task CheckExistenceByEmail(RegisterCommand command, List<Error> errors)
    {
        bool isExistByEmail = await _unitOfWork.UserRepository.IsExistByEmailAsync(EmailAddress.Create(command.Email));

        if (isExistByEmail)
        {
            errors.Add(Errors.User.AlreadyExistByEmail(command.Email));
        }
    }

    private async Task CheckExistenceByUserName(RegisterCommand command, List<Error> errors)
    {
        bool isExistByUserName = await _unitOfWork.UserRepository.IsExistByUserNameAsync(command.UserName);

        if (isExistByUserName)
        {
            errors.Add(Errors.User.AlreadyExistByUserName(command.UserName));
        }
    }

    private Role? GetRole(RegisterCommand command, List<Error> errors)
    {
        Role? role = null;

        if (command.RoleId is null)
        {
            role = Role.Client;
            return role;
        }
        
        role = GuidEnumeration.GetAll<Role>().FirstOrDefault(x => x.Id == command.RoleId);

        if (role is null)
        {
            errors.Add(Errors.Role.NotFoundById(command.RoleId.ToString()));
        }
        

        return role;
    }

    private User CreateUser(RegisterCommand command, Role? role)
    {
        var fullName = FullName.Create(command.Surname, command.Name, command.Patronymic);

        var user = User.Create(
            command.UserName,
            fullName,
            EmailAddress.Create(command.Email),
            Password.Create(command.Password),
            role);

        return user;
    }
}
