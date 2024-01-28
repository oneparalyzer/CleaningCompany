using CleaningCompany.Application.Common.Interfaces.Repositories;
using CleaningCompany.Domain.AggregateModels.UserAggregate;
using CleaningCompany.Domain.AggregateModels.UserAggregate.Enums;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.ValueObjects;
using CleaningCompany.Infrastructure.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleaningCompany.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly SignInManager<CustomIdentityUser> _signInManager;

    public UserRepository(
        UserManager<CustomIdentityUser> userManager, 
        SignInManager<CustomIdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<User?> GetByIdAsync(UserId id)
    {
        CustomIdentityUser? identityUser = await _userManager.FindByIdAsync(id.Value.ToString());
        if (identityUser is null)
        {
            return null;
        }

        return Adapt(identityUser);
    }

    public async Task<bool> TryPasswordSignInAsync(
        string userName, 
        string password, 
        bool rememberMe)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(
            userName,
            password,
            rememberMe,
            false);

        return signInResult.Succeeded;
    }

    public async Task CreateAndSaveAsync(User user)
    {
        CustomIdentityUser identityUser = Adapt(user);

        await _userManager.CreateAsync(identityUser, user.Password.Value);

        await _userManager.AddToRoleAsync(identityUser, user.Role.Name);
    }

    public async Task<bool> IsExistByEmailAsync(EmailAddress email)
    {
        return await _userManager.FindByEmailAsync(email.Value) is not null;
    }

    public async Task<bool> IsExistByUserNameAsync(string userName)
    {
        return await _userManager.FindByNameAsync(userName) is not null;
    }

    private CustomIdentityUser Adapt(User user)
    {
        return new CustomIdentityUser
        {
            Name = user.FullName.Name,
            Surname = user.FullName.Surname,
            Patronymic = user.FullName.Patronymic,
            Id = user.Id.Value,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            UserName = user.Name,
            NormalizedUserName = user.Name.ToUpper(),
            Email = user.EmailAddress.Value,
            NormalizedEmail = user.EmailAddress.Value.ToString().ToUpper(),
        };
    }

    private User Adapt(CustomIdentityUser identityUser)
    {
        return User.Create(
            identityUser.Name,
            FullName.Create(
                identityUser.Surname,
                identityUser.Name,
                identityUser.Patronymic),
            EmailAddress.Create(identityUser.Email),
            Password.Create("jdkfsdj"),
            Role.Admin);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<bool> IsExistByIdAsync(UserId userId)
    {
        return await _userManager.FindByIdAsync(userName) is not null;
    }
}
