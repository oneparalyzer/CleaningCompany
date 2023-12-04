using Microsoft.AspNetCore.Identity;

namespace CleaningCompany.Infrastructure.Identity.Entities;

public sealed class CustomIdentityUser : IdentityUser<Guid>
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Patronymic { get; set; } = null!;
}
