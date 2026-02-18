using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.StudentGroup.Exceptions;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities.StudentGroup;

public class StudentGroupEntity : EntityBase
{
    public GroupName Name { get; private set; }

    /// <exception cref="StudentGroupNameNullException"></exception>
    public StudentGroupEntity(Guid id, GroupName name) : base(id)
    {
        if (name is null)
            throw new StudentGroupNameNullException();

        Name = name;
    }
}
