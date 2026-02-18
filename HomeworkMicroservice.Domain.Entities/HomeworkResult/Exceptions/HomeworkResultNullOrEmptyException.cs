namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultNullOrEmptyException : ArgumentNullException
{
    public override string Message => "Homework result cannot be null or empty";
}
