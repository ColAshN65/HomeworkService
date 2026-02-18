using HomeworkMicroservice.Domain.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class PersonName : ValueObject<string>
{
    public override string Value { get; }

    /// <exception cref="PersonNameNullOrEmptyException"></exception>
    public PersonName(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new PersonNameNullOrEmptyException();

        Value = name;
    }

    public override bool Equals(IValueObject? other)
    {
        if (other is PersonName personName)
            return Value.Equals(personName.Value);

        return false;
    }
}
