using HomeworkMicroservice.Domain.Entities.Base;

namespace HomeworkMicroservice.Domain.Entities;

public class Media(Guid id, Uri url) : EntityBase(id)
{
    public Uri Url { get; } = url;
}
