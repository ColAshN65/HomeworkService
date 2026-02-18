namespace HomeworkMicroservice.Domain.Entities.Student.Exceptions;

public class StudentHomeworkResultStatusException : ArgumentException
{
    public override string Message => "Student cannot change or cancel homework result which status is not AwaitingCheck";
}
