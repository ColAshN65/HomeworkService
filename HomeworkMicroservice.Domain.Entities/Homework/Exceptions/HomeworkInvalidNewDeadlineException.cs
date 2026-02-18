namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkInvalidNewDeadlineException : ArgumentException
{
    public override string Message => "New value of homework deadline cannot be earlier than old value";
}
