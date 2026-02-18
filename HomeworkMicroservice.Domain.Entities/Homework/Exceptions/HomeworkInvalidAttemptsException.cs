namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkInvalidAttemptsException : ArgumentException
{
    public override string Message => "Attempts of homework cannot be less than 1";
}
