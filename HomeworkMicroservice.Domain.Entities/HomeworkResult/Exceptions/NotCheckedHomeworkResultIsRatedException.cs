namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class NotCheckedHomeworkResultIsRatedException : ArgumentException
{
    public override string Message => "Homework result cannot have a grade if it is not checked";
}
