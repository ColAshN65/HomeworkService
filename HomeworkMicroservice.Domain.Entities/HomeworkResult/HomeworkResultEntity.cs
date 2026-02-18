using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.Grade;
using HomeworkMicroservice.Domain.Entities.Homework;
using HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;
using HomeworkMicroservice.Domain.Entities.Student;
using HomeworkMicroservice.Domain.ValueObjects;

namespace HomeworkMicroservice.Domain.Entities.HomeworkResult;

public class HomeworkResultEntity : EntityBase
{
    public HomeworkEntity Homework { get; }
    public StudentEntity Student { get; }
    public AvailableDateTime UpdateTime { get; private set; }
    public string Result { get; private set; }
    public HomeWorkState State { get; private set; }
    public GradeEntity? Grade { get; private set; }
    public string? Comment { get; private set; }

    /// <exception cref="HomeworkResultSourceNullException"></exception>
    /// <exception cref="HomeworkResultStudentNullException"></exception>
    /// <exception cref="HomeworkResultUpdateTimeNullException"></exception>
    /// <exception cref="HomeworkResultNullOrEmptyException"></exception>
    /// <exception cref="NotCheckedHomeworkResultIsRatedException"></exception>
    /// <exception cref="CheckedHomeworkResultIsNotRatedException"></exception>
    public HomeworkResultEntity(
       Guid id,
       HomeworkEntity homework,
       StudentEntity student,
       AvailableDateTime updateTime,
       HomeWorkState state,
       string result,
       GradeEntity? grade,
       string? comment) : base(id)
    {
        if (homework is null)
            throw new HomeworkResultSourceNullException();

        if (student is null)
            throw new HomeworkResultStudentNullException();

        if (updateTime is null)
            throw new HomeworkResultUpdateTimeNullException();

        if (string.IsNullOrEmpty(result))
            throw new HomeworkResultNullOrEmptyException();

        if (state is not HomeWorkState.Checked && grade is not null)
            throw new NotCheckedHomeworkResultIsRatedException();

        if (state is HomeWorkState.Checked && grade is null)
            throw new CheckedHomeworkResultIsNotRatedException();

        Homework = homework;
        Student = student;
        UpdateTime = updateTime;
        Result = result;
        State = state;
        Grade = grade;
        Comment = comment;
    }


    /// <exception cref="HomeworkResultRetakeWithoutAwaitingException"></exception>
    /// <exception cref="HomeworkResultNullOrEmptyException"></exception>
    public void Retake(string newResult)
    {
        if (State is not HomeWorkState.AwaitingRetake and not HomeWorkState.AwaitingCheck)
            throw new HomeworkResultRetakeWithoutAwaitingException();

        if (string.IsNullOrEmpty(newResult))
            throw new HomeworkResultNullOrEmptyException();

        Result = newResult;
        State = HomeWorkState.AwaitingCheck;
        UpdateTime = new AvailableDateTime(DateTime.UtcNow);
    }

    /// <exception cref="HomeworkResultCheckingWithoutAwaiting"></exception>
    public void StartCheck()
    {
        if (State is not HomeWorkState.AwaitingCheck)
            throw new HomeworkResultCheckingWithoutAwaiting();

        State = HomeWorkState.OnChecking;
    }


    /// <exception cref="HomeworkResultCheckedWithoutCheckingException"></exception>
    /// <exception cref="HomeworkResultGradeNullOnApproveException"></exception>
    public void Approve(string? comment, GradeEntity grade)
    {
        if (State is not HomeWorkState.OnChecking)
            throw new HomeworkResultCheckedWithoutCheckingException();

        if (grade is null)
            throw new HomeworkResultGradeNullOnApproveException();

        Comment = comment;
        State = HomeWorkState.Checked;
    }


    /// <exception cref="HomeworkResultCheckedWithoutCheckingException"></exception>
    public void Deny(string? comment)
    {
        if (State is not HomeWorkState.OnChecking)
            throw new HomeworkResultCheckedWithoutCheckingException();

        State = HomeWorkState.AwaitingRetake;
    }
}
