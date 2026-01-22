using System.Numerics;

namespace HomeworkMicroservice.Domain.ValueObjects.Base;

public interface IValueObject<TSelf>
    : IEquatable<ValueObject>,
    IEqualityOperators<TSelf, TSelf, bool>
    where TSelf : IValueObject<TSelf>
{

}
