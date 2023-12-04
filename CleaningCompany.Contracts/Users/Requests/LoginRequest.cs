namespace CleaningCompany.Contracts.Users.Requests;

public record LoginRequest(
    string UserName,
    string Password);
