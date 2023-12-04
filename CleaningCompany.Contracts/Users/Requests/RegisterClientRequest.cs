namespace CleaningCompany.Contracts.Auth.Requests;

public record RegisterClientRequest(
    string Surname,
    string Name,
    string Patronymic,
    string Email,
    string UserName,
    string Password,
    string PasswordConfirm);
