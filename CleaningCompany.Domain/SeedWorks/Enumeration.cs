using System.Reflection;

namespace CleaningCompany.Domain.SeedWorks;

public abstract class Enumeration<TKey> : IComparable
{
    public string Name { get; private set; }

    public TKey Id { get; private set; }

    protected Enumeration(TKey id, string name) => (Id, Name) = (id, name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration<TKey> =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration<TKey> otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public int CompareTo(object? obj)
    {
        //if (obj is null) return 1;
        //
        //if (obj is Enumeration<TKey> otherValue)
        //{
        //    return Id.CompareTo(otherValue.Id);
        //}
        
        throw new ArgumentException("Object is not an Enumeration");
    }
}
