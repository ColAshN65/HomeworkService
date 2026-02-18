using HomeworkMicroservice.Domain.Entities.Base;

namespace HomeworkMicroservice.Domain.Entities.Grade;

public class GradeEntity(Guid id, int value) : EntityBase(id)
{
    public int Value { get; } = value;
}
