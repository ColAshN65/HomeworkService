using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.Grade;
using HomeworkMicroservice.Domain.Entities.Homework;
using HomeworkMicroservice.Domain.Entities.Homework.Exceptions;
using HomeworkMicroservice.Domain.Entities.HomeworkResult;
using HomeworkMicroservice.Domain.Entities.Lesson;
using HomeworkMicroservice.Domain.Entities.StudentGroup;
using HomeworkMicroservice.Domain.Entities.Teacher.Exceptions;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities.Teacher;

public class TeacherEntity : Person
{
    public IReadOnlyCollection<HomeworkEntity> Homeworks { get => _homeworks; }
    public IReadOnlyCollection<HomeworkResultEntity> HomeWorkResults { get => _homeworkResults; }

    private HashSet<HomeworkEntity> _homeworks;
    private HashSet<HomeworkResultEntity> _homeworkResults;

    /// <exception cref="TeacherHomeworkCollectionNullException"></exception>
    /// <exception cref="TeacherHomeworkResultCollectionNullException"></exception>
    public TeacherEntity(
        Guid id,
        PersonFullName name,
        IEnumerable<HomeworkEntity> homeworks,
        IEnumerable<HomeworkResultEntity> homeworkResults) : base(id, name)
    {
        if (homeworks is null)
            throw new TeacherHomeworkCollectionNullException();

        if (homeworkResults is null)
            throw new TeacherHomeworkResultCollectionNullException();

        _homeworks = [.. homeworks];
        _homeworkResults = [.. homeworkResults];
    }

    /// <exception cref="HomeworkDeadlineNullException"></exception>
    /// <exception cref="HomeworkInvalidDeadlineException"></exception>
    /// <exception cref="HomeworkGroupsCollectionNullOrEmptyException"></exception>
    /// <exception cref="HomeworkLessonNullException"></exception>
    /// <exception cref="HomeworkTitleNullOrEmptyException"></exception>
    /// <exception cref="HomeworkInvalidAttemptsException"></exception>
    public void CreateHomework(
        AvailableDateTime deadline,
        IEnumerable<StudentGroupEntity> studentGroups,
        LessonEntity lesson,
        string title, 
        int attempts)
    {
        var newHomework = new HomeworkEntity(
            Guid.NewGuid(),
            new AvailableDateTime(DateTime.UtcNow),
            deadline,
            this,
            studentGroups,
            lesson,
            title,
            attempts);


        _homeworks.Add(newHomework);
    }

    public void CancelHomework(HomeworkEntity homework)
    {
        if (homework.Teacher != this)
            throw new TeacherHomeworkOwnershipException();

        _homeworks.Remove(homework);
    }

    public void ChangeHomeworkTitle(HomeworkEntity homework, string newTitle)
    {
        if (homework.Teacher != this)
            throw new TeacherHomeworkOwnershipException();

        homework.ChangeTitle(newTitle);
    }

    public void ChangeHomeworkDeadline(HomeworkEntity homework, AvailableDateTime newDeeadline)
    {
        if (homework.Teacher != this)
            throw new TeacherHomeworkOwnershipException();

        homework.ChangeDeadline(newDeeadline);
    }

    public void StartCheckHomeworkResult(HomeworkResultEntity result)
    {
        if (result.Homework.Teacher != this)
            throw new TeacherHomeworkOwnershipException();

        result.StartCheck();
    }

    public void ApproveHomeworkResult(HomeworkResultEntity result, GradeEntity grade, string comment)
    {
        if (result.Homework.Teacher != this)
            throw new TeacherHomeworkOwnershipException();

        result.Approve(comment, grade);
    }

    public void DenyHomeworkResult(HomeworkResultEntity result, string comment)
    {
        if (result.Homework.Teacher != this)
            throw new TeacherHomeworkOwnershipException();

        result.Deny(comment);
    }
}