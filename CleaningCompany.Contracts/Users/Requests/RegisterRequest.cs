namespace CleaningCompany.Contracts.Users.Requests;

public record RegisterRequest(
    string Surname,
    string Name,
    string Patronymic,
    string Email,
    string UserName,
    string Password,
    string PasswordConfirm,
    Guid? RoleId = null);
