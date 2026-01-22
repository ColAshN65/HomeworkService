using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities;

public class StudentGroup(Guid id, GroupName name) : EntityBase(id)
{
    public GroupName Name { get; private set; } = name;
}
