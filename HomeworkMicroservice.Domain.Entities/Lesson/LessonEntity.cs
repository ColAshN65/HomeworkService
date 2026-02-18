using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.Lesson.Exceptions;
using HomeworkMicroservice.Domain.Entities.Media;
using System.Security.Cryptography;

namespace HomeworkMicroservice.Domain.Entities.Lesson;

public class LessonEntity : EntityBase
{
    public string Title { get; private set; }
    public IReadOnlyCollection<MediaEntity> Media { get => _media; }

    private readonly HashSet<MediaEntity> _media;

    /// <exception cref="LessonTitleNullOrEmptyException"></exception>
    /// <exception cref="LessonMediaNullExceptionn"></exception>
    public LessonEntity(
        Guid id,
        string title,
        IEnumerable<MediaEntity> media) 
        : base(id)
    {
        if (string.IsNullOrEmpty(title))
            throw new LessonTitleNullOrEmptyException();

        if (media is null)
            throw new LessonMediaNullExceptionn();

        Title = title;
        _media = [.. media];
    }
}
