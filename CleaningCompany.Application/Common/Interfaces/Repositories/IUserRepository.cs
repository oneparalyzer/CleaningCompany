using CleaningCompany.Domain.AggregateModels.UserAggregate;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;

namespace CleaningCompany.Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    Task<bool> TryPasswordSignInAsync(string userName, string password, bool rememberMe);
    Task LogoutAsync();
    Task CreateAndSaveAsync(User user);
    Task<bool> IsExistByEmailAsync(EmailAddress email);
    Task<bool> IsExistByUserNameAsync(string userName);
    Task<User?> GetByIdAsync(UserId id);
}
