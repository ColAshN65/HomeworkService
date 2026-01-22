using HomeworkMicroservice.Domain.Entities.Base;

namespace HomeworkMicroservice.Domain.Entities;

public class Lesson(Guid id, string title) : EntityBase(id)
{
    public string Title { get; private set; } = title;
}
