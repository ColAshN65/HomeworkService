namespace HomeworkMicroservice.Domain.ValueObjects.Base;

//TODO: GetHashCode...
public abstract class ValueObject : IValueObject<ValueObject>
{
    public override bool Equals(object? obj)
    {
        if (obj is ValueObject valueObject)
            return Equals(valueObject);

        return false;
    }

    public abstract bool Equals(ValueObject? other);

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null)
            return true;

        return left?.Equals(right) ?? false;
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
        => !(left == right);
}