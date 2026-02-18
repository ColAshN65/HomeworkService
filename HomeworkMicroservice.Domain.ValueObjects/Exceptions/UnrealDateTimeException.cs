namespace HomeworkMicroservice.Domain.ValueObjects.Exceptions;

public class UnrealDateTimeException : ArgumentOutOfRangeException
{
    public override string Message => "Available DateTime must be between 2024 and one year later than the current date.";
}
