using System.Numerics;

namespace HomeworkMicroservice.Domain.ValueObjects.Base;

public abstract class ValueObject : 
    IValueObject,
    IEqualityOperators<ValueObject, ValueObject, bool>
{
    public override bool Equals(object? obj)
    {
        if (obj is ValueObject valueObject)
            return Equals(valueObject);

        return false;
    }

    public abstract bool Equals(IValueObject? other);
    public override abstract int GetHashCode();

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null)
            return true;

        return left?.Equals(right) ?? false;
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
        => !(left == right);

}

//TODO: Need not nullable analyzer
public abstract class ValueObject<TValue> : ValueObject
    where TValue : notnull
{
    public abstract TValue Value { get; }

    public override int GetHashCode()
        => Value.GetHashCode();
}