namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultRetakeWithoutAwaitingException : ArgumentException
{
    public override string Message => "Homework result cannot be retake when it not awaiting";
}
