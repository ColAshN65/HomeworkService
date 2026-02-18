namespace HomeworkMicroservice.Domain.Entities.Teacher.Exceptions;

public class TeacherHomeworkCollectionNullException : ArgumentNullException
{
    public override string Message => "Homework collection of teacher cannot be null";
}
