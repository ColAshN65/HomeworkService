namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultCheckingWithoutAwaiting : ArgumentException
{
    public override string Message => "Homework result cannot be checked when it not awaiting";
}
