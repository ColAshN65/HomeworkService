namespace HomeworkMicroservice.Domain.Entities.Teacher.Exceptions;

public class TeacherHomeworkResultCollectionNullException : ArgumentNullException
{
    public override string Message => "Homework result collection of teacher cannot be null";
}
