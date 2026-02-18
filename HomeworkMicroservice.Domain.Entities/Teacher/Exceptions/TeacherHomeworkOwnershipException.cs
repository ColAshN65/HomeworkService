namespace HomeworkMicroservice.Domain.Entities.Teacher.Exceptions;

public class TeacherHomeworkOwnershipException : ArgumentException
{
    public override string Message => "Teacher cannot check homework results and change homework that they are not the owner of";
}
