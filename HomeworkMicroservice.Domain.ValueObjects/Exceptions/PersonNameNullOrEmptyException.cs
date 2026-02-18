namespace HomeworkMicroservice.Domain.ValueObjects.Exceptions;

public class PersonNameNullOrEmptyException : ArgumentNullException
{
    public override string Message => "Person name cannot be null or empty";
}
