namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;
public class CheckedHomeworkResultIsNotRatedException : ArgumentException
{
    public override string Message => "Homework result must have a grade if it is checked";
}
