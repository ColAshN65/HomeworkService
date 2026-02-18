namespace HomeworkMicroservice.Domain.Entities.Student.Exceptions;

public class StudentHomeworkResultOwnershipException : ArgumentException
{
    public override string Message => "Student cannot change homework result that they are not the owner of";
}
