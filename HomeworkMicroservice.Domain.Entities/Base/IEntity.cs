using System.Numerics;

namespace HomeworkMicroservice.Domain.Entities.Base;

public interface IEntity<TKey> : IEquatable<IEntity<TKey>>
{
    TKey Id { get; }
}
