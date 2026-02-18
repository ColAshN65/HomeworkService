namespace HomeworkMicroservice.Domain.Entities.Homework.Exceptions;

public class HomeworkGroupsCollectionNullOrEmptyException : ArgumentNullException
{
    public override string Message => "Groups collection of homework cannot be null or empty";
}
