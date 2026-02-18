namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultUpdateTimeNullException : ArgumentNullException
{
    public override string Message => "Homework update time cannot be null";
}
