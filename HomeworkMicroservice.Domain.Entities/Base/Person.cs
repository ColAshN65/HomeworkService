using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities.Base;

public abstract class Person(Guid id, PersonFullName name) : EntityBase(id)
{
    public PersonFullName Name { get; private set; } = name;
}
