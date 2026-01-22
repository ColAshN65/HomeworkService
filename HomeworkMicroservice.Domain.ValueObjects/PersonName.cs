using HomeworkMicroservice.Domain.ValueObjects.Base;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class PersonName : ValueObject
{
    public string Name { get; }

    public PersonName(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Argument is null or empty", nameof(name));

        Name = name;
    }

    public override bool Equals(ValueObject? other)
    {
        if (other is PersonName personName)
            return Name.Equals(personName.Name);

        return false;
    }
}
