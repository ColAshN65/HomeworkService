using System.Numerics;

namespace HomeworkMicroservice.Domain.Entities.Base;

public interface IEntity<TKey, TSelf> 
    : IEquatable<TSelf>,
    IEqualityOperators<TSelf, TSelf, bool>
    where TKey : struct
    where TSelf : IEntity<TKey, TSelf>
{
    TKey Id { get; }
}
