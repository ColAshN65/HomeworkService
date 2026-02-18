namespace HomeworkMicroservice.Domain.Entities.Student.Exceptions;

public class StudentHomeworkAttemptOverException : ArgumentException
{
    public override string Message => "Student cannot send homework result for which homework he spent attempts";
}
