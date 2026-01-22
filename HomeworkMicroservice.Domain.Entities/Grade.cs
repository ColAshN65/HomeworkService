using HomeworkMicroservice.Domain.Entities.Base;

namespace HomeworkMicroservice.Domain.Entities;

public class Grade(Guid id, int value) : EntityBase(id)
{
    public int Value { get; } = value;
}
