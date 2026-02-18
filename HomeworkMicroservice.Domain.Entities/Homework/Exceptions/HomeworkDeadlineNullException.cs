namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkDeadlineNullException : ArgumentNullException
{
    public override string Message => "Deadline of homework cannot be null";
}
