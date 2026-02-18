namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkLessonNullException : ArgumentNullException
{
    public override string Message => "Lesson of homework cannot be null";
}
