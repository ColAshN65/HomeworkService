namespace HomeworkMicroservice.Domain.Entities.Media.Exceptions;

public class MediaUrlNullException : ArgumentNullException
{
    public override string Message => "Url of media connot be null";
}
