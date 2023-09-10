using System.Reflection;

namespace Domain.Common;

public abstract class Enumeration<TType> : IComparable
{
    public TType Value { get; }

    public int Id { get; }

    protected Enumeration(int id, TType name) => (Id, Value) = (id, name);

    public static IEnumerable<T> GetAll<T>() where T : Enumeration<TType> =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration<TType> otherValue)
        {
            return false;
        }

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Id);
    }

    public int CompareTo(object other) => Id.CompareTo(((Enumeration<TType>)other).Id);
}