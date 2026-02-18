namespace HomeworkMicroservice.Domain.Entities.Student.Exceptions;

public class StudentGroupCollectionNullOrEmptyException : ArgumentNullException
{
    public override string Message => "Collection of groups of student cannot be null or empty";
}
