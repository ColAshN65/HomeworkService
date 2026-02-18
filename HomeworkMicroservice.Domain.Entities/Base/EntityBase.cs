using System.Numerics;

namespace HomeworkMicroservice.Domain.Entities.Base;

public abstract class EntityBase(Guid id) : 
    IEntity<Guid>,
    IEqualityOperators<EntityBase, EntityBase, bool>
{
    public Guid Id { get; } = id;

    public override int GetHashCode()
        => Id.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (obj is EntityBase entityBase)
            return Equals(entityBase);

        return false;
    }

    public bool Equals(IEntity<Guid>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return other.Id == Id;
    }


    public static bool operator ==(EntityBase? left, EntityBase? right)
    {
        if (left is null && right is null) 
            return true;

        return left?.Equals(right) ?? false;
    }

    public static bool operator !=(EntityBase? left, EntityBase? right)
        => !(left == right);
}
