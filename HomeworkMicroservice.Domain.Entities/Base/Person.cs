using HomeworkMicroservice.Domain.Entities.Base.Exceptions;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities.Base;

public abstract class Person : EntityBase
{
    public PersonFullName Name { get; private set; }

    /// <exception cref="PersonFullNameNullException"></exception>
    public Person(Guid id, PersonFullName name) : base(id)
    {
        if (name is null)
            throw new PersonFullNameNullException();

        Name = name;
    }
}
