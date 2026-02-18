using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.Homework;
using HomeworkMicroservice.Domain.Entities.HomeworkResult;
using HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;
using HomeworkMicroservice.Domain.Entities.Student.Exceptions;
using HomeworkMicroservice.Domain.Entities.StudentGroup;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities.Student;

public class StudentEntity: Person
{
    public IReadOnlyCollection<StudentGroupEntity> Groups { get => _groups; }
    public IReadOnlyCollection<HomeworkEntity> Homeworks { get => _homeworks; }
    public IReadOnlyCollection<HomeworkResultEntity> HomeWorkResults { get => _homeworkResults; }

    private HashSet<StudentGroupEntity> _groups;
    private HashSet<HomeworkEntity> _homeworks;
    private HashSet<HomeworkResultEntity> _homeworkResults;

    /// <exception cref="StudentGroupCollectionNullOrEmptyException"></exception>
    /// <exception cref="StudentHomeworkCollectionNullException"></exception>
    /// <exception cref="StudentHomeworkResultCollectionNullException"></exception>
    public StudentEntity(
        Guid id,
        PersonFullName name,
        IEnumerable<StudentGroupEntity> groups,
        IEnumerable<HomeworkEntity> homeworks,
        IEnumerable<HomeworkResultEntity> homeworkResults)
        : base(id, name)
    {
        if (groups is null || !groups.Any())
            throw new StudentGroupCollectionNullOrEmptyException();

        if (homeworks is null)
            throw new StudentHomeworkCollectionNullException();

        if (homeworkResults is null)
            throw new StudentHomeworkResultCollectionNullException();

        _groups = [.. groups];
        _homeworks = [.. homeworks];
        _homeworkResults = [.. homeworkResults];
    }

    /// <exception cref="StudentNotAssignedHomeworkException"></exception>
    /// <exception cref="StudentHomeworkAttemptOverException"></exception>
    /// <exception cref="HomeworkResultNullOrEmptyException"></exception>
    public void CreateHomeworkResult(HomeworkEntity homework, string result)
    {
        if (!CheckAssigninng(homework))
            throw new StudentNotAssignedHomeworkException();

        if (_homeworkResults.Count(homeworkResult => homeworkResult.Homework == homework) >= homework.Attempts)
            throw new StudentHomeworkAttemptOverException();

        var homeworkResult = new HomeworkResultEntity(
            Guid.NewGuid(),
            homework,
            this,
            new AvailableDateTime(DateTime.UtcNow),
            HomeWorkState.AwaitingCheck,
            result,
            null,
            null);

        _homeworkResults.Add(homeworkResult);
    }

    /// <exception cref="StudentHomeworkResultOwnershipException"></exception>
    /// <exception cref="StudentNotAssignedHomeworkException"></exception>
    /// <exception cref="StudentHomeworkResultStatusException"></exception>
    public void ChangeHomeworkResult(HomeworkResultEntity homeworkResult, string newResult)
    {
        if (homeworkResult.Student != this)
            throw new StudentHomeworkResultOwnershipException();

        if (!CheckAssigninng(homeworkResult.Homework))
            throw new StudentNotAssignedHomeworkException();

        if (homeworkResult.State is not HomeWorkState.AwaitingCheck and not HomeWorkState.AwaitingRetake)
            throw new StudentHomeworkResultStatusException();

        homeworkResult.Retake(newResult);
    }

    /// <exception cref="StudentHomeworkResultOwnershipException"></exception>
    /// <exception cref="StudentHomeworkResultStatusException"></exception>
    public void CancelHomeworkResult(HomeworkResultEntity homeworkResult)
    {
        if (homeworkResult.Student != this)
            throw new StudentHomeworkResultOwnershipException();

        if (homeworkResult.State is not HomeWorkState.AwaitingCheck)
            throw new StudentHomeworkResultStatusException();

        _homeworkResults.Remove(homeworkResult);
    }

    private bool CheckAssigninng(HomeworkEntity homework)
    {
        foreach (var group in _groups)
        {
            if (homework.Groups.Contains(group))
                return true;
        }

        return false;
    }
}
