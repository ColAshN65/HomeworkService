namespace HomeworkMicroservice.Domain.Entities.StudentGroup.Exceptions;

public class StudentGroupNameNullException : ArgumentNullException
{
    public override string Message => "Name of student group cannot be null";
}
