namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkInvalidDeadlineException : ArgumentException
{
    public override string Message => "Deeadline of homework cannot be earlier of creation time";
}
