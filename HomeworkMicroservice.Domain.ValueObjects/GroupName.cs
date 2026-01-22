using HomeworkMicroservice.Domain.ValueObjects.Base;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class GroupName : ValueObject
{
    public string Name { get ; }

    public GroupName(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Argument is null or empty", nameof(name));

        if (name.Length > 10)
            throw new ArgumentException("Group name is too big", nameof(name));

        Name = name;
    }

    public override bool Equals(ValueObject? other)
    {
        if (other is GroupName groupName)
            return Name.Equals(groupName.Name);

        return false;
    }
}
