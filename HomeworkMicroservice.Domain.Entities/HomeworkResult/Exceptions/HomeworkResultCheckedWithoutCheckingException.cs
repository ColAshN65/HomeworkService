namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultCheckedWithoutCheckingException : ArgumentException
{
    public override string Message => "Homework result cannot be checked when it not checking";
}
