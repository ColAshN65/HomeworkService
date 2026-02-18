namespace HomeworkMicroservice.Domain.Entities.Lesson.Exceptions;

public class LessonTitleNullOrEmptyException : ArgumentNullException
{
    public override string Message => "Title of lesson cannot be null or empty";
}
