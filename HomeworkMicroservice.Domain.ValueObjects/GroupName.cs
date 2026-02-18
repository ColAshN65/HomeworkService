using HomeworkMicroservice.Domain.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class GroupName : ValueObject<string>
{
    public override string Value { get; }

    public static readonly byte MaxValue = 10;

    /// <exception cref="GroupNameNullOrEmptyException"></exception>
    /// <exception cref="GroupNameTooLongException"></exception>
    public GroupName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new GroupNameNullOrEmptyException();

        if (name.Length > MaxValue)
            throw new GroupNameTooLongException();

        Value = name;
    }

    public override bool Equals(IValueObject? other)
    {
        if (other is GroupName availableDateTime)
            return Value.Equals(availableDateTime.Value);

        return false;
    }
}
