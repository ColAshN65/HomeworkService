namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkTitleNullOrEmptyException : ArgumentNullException
{
    public override string Message => "Title homework cannot be null or empty";
}
