namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultStudentNullException : ArgumentNullException
{
    public override string Message => "Homework result student cannot be null";
}
