using CleaningCompany.Domain.AggregateModels.UserAggregate.Enums;
using CleaningCompany.Domain.AggregateModels.UserAggregate.ValueObjects;
using CleaningCompany.Domain.Common.ValueObjects;
using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private User(
        UserId id, 
        FullName fullName,
        string name, 
        EmailAddress emailAddress, 
        Password password, 
        Role role) : base(id)
    {
        Name = name;
        Role = role;
        FullName = fullName;
        Password = password;
        EmailAddress = emailAddress;
    }

    public FullName FullName { get; private set; }
    public string Name { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public Password Password { get; private set; }
    public Role Role { get; private set; }

    public static User Create(string name, FullName fullName, EmailAddress emailAddress, Password password, Role role)
    {
        return new User(UserId.Create(), fullName, name, emailAddress, password, role); 
    }

    public static User CreateClient(string name, FullName fullName, EmailAddress emailAddress, Password password)
    {
        return new User(UserId.Create(), fullName, name, emailAddress, password, Role.Client);
    }
}
