namespace HomeworkMicroservice.Domain.Entities.Student.Exceptions;

public class StudentHomeworkCollectionNullException : ArgumentNullException
{
    public override string Message => "Collection of homeworks of student cannot be null";
}
