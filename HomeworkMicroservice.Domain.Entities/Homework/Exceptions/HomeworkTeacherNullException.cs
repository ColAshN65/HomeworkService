namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkTeacherNullException : ArgumentNullException
{
    public override string Message => "Teacher of homework cannot be null";
}
