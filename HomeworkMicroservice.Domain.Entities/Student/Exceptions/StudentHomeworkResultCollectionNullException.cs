namespace HomeworkMicroservice.Domain.Entities.Student.Exceptions;

public class StudentHomeworkResultCollectionNullException : ArgumentNullException
{
    public override string Message => "Collection of homework results of student cannot be null";
}
