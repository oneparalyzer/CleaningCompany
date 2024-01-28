using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.AggregateModels.UserAggregate.Enums;

public sealed class Role : Enumeration<Guid>
{
    private Role(Guid id, string name) : base(id, name) { }

    public static readonly Role Admin = new(Guid.Parse("f08ca38d-8694-4577-8115-74fde5e9b90e"), nameof(Admin));
    public static readonly Role Worker = new(Guid.Parse("cba82390-5dd1-4545-b4a7-0ec915c03282"), nameof(Worker));
    public static readonly Role Client = new(Guid.Parse("a0626919-8369-4150-a624-324f1ee118d9"), nameof(Client));
}
