using CleaningCompany.Domain.SeedWorks;

namespace CleaningCompany.Domain.Common.ValueObjects;

public sealed class FullName : ValueObject
{
    private FullName(string surname, string name, string patronymic)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
    }

    public string Surname { get; }
    public string Name { get; }
    public string Patronymic { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Surname;
        yield return Name;
        yield return Patronymic;
    }

    public static FullName Create(string surname, string name, string patronymic)
    {
        return new FullName(surname, name, patronymic);
    }
}
