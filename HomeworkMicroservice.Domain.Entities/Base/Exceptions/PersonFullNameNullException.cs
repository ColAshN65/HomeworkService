namespace HomeworkMicroservice.Domain.Entities.Base.Exceptions;

public class PersonFullNameNullException : ArgumentNullException
{
    public override string Message => "Person fuulname cannot be null";
}
