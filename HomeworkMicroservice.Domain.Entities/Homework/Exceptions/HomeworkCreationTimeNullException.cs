namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkCreationTimeNullException : ArgumentNullException
{
    public override string Message => "Creation time of homework cannot be null";
}
