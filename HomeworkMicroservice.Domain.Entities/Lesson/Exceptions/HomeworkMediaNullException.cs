namespace HomeworkMicroservice.Domain.Entities.Lesson.Exceptions;

public class LessonMediaNullExceptionn : ArgumentNullException
{
    public override string Message => "Collection of media of lesson cannot be null";
}
