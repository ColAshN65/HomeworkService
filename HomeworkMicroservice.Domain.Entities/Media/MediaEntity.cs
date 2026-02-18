using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.Media.Exceptions;

namespace HomeworkMicroservice.Domain.Entities.Media;

public class MediaEntity : EntityBase
{
    public Uri Url { get; }

    /// <exception cref="MediaUrlNullException"></exception>
    public MediaEntity(Guid id, Uri url) : base(id)
    {
        if (url is null)
            throw new MediaUrlNullException();

        Url = url;  
    }
}
