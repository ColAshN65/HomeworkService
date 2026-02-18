namespace HomeworkMicroservice.Domain.Entities.HomeworkResult.Exceptions;

public class HomeworkResultSourceNullException : ArgumentNullException
{
    public override string Message => "Source homework of homework result cannot be null";
}
