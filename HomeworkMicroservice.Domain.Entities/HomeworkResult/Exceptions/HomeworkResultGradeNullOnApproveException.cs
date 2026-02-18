namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultGradeNullOnApproveException : ArgumentNullException
{
    public override string Message => "Homework result should have a grade on approve";
}
