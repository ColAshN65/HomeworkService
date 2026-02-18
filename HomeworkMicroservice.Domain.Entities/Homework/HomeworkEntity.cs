using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.Homework.Exceptions;
using HomeworkMicroservice.Domain.Entities.Lesson;
using HomeworkMicroservice.Domain.Entities.Lesson.Exceptions;
using HomeworkMicroservice.Domain.Entities.Media;
using HomeworkMicroservice.Domain.Entities.StudentGroup;
using HomeworkMicroservice.Domain.Entities.Teacher;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities.Homework;

public class HomeworkEntity : EntityBase
{
    public AvailableDateTime CreationTime { get; private set; }
    public AvailableDateTime Deadline { get; private set; }
    public TeacherEntity Teacher { get; }
    public IReadOnlyCollection<StudentGroupEntity> Groups { get => _groups; }
    public LessonEntity Lesson { get; }
    public string Title { get; private set; }
    public int Attempts { get; private set; }

    private readonly HashSet<StudentGroupEntity> _groups;

    /// <exception cref="HomeworkCreationTimeNullException"></exception>
    /// <exception cref="HomeworkDeadlineNullException"></exception>
    /// <exception cref="HomeworkInvalidDeadlineException"></exception>
    /// <exception cref="HomeworkTeacherNullException"></exception>
    /// <exception cref="HomeworkGroupsCollectionNullOrEmptyException"></exception>
    /// <exception cref="HomeworkLessonNullException"></exception>
    /// <exception cref="HomeworkTitleNullOrEmptyException"></exception>
    /// <exception cref="HomeworkInvalidAttemptsException"></exception>
    public HomeworkEntity(
        Guid id,
        AvailableDateTime creationTime,
        AvailableDateTime deadline,
        TeacherEntity teacher,
        IEnumerable<StudentGroupEntity> groups,
        LessonEntity lesson,
        string title,
        int attempts) : base(id)
    {
        if (creationTime is null)
            throw new HomeworkCreationTimeNullException();

        if (deadline is null)
            throw new HomeworkDeadlineNullException();

        if (deadline.Value < creationTime.Value)
            throw new HomeworkInvalidDeadlineException();

        if (teacher is null)
            throw new HomeworkTeacherNullException();

        if (groups is null || !groups.Any())
            throw new HomeworkGroupsCollectionNullOrEmptyException();

        if (lesson is null)
            throw new HomeworkLessonNullException();

        if (string.IsNullOrEmpty(title))
            throw new HomeworkTitleNullOrEmptyException();

        if (attempts < 1)
            throw new HomeworkInvalidAttemptsException();

        CreationTime = creationTime;
        Deadline = deadline;
        Teacher = teacher;
        _groups = [.. groups];
        Lesson = lesson;
        Title = title;
        Attempts = attempts;
    }

    /// <exception cref="HomeworkTitleNullOrEmptyException"></exception>
    public void ChangeTitle(string newTitle)
    {
        if (string.IsNullOrEmpty(newTitle))
            throw new HomeworkTitleNullOrEmptyException();

        Title = newTitle;
    }

    /// <exception cref="HomeworkDeadlineNullException"></exception>
    /// <exception cref="HomeworkInvalidNewDeadlineException"></exception>
    public void ChangeDeadline(AvailableDateTime newDeadline)
    {
        if (newDeadline is null)
            throw new HomeworkDeadlineNullException();

        if (newDeadline.Value < Deadline.Value)
            throw new HomeworkInvalidNewDeadlineException();

        Deadline = newDeadline;
    }
}
