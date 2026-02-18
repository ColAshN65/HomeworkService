namespace HomeworkMicroservice.Domain.Entities.Student.Exceptions;

public class StudentNotAssignedHomeworkException : ArgumentException
{
    public override string Message => "Student cannot send or change homework result for homework whish not assigned for him";
}
