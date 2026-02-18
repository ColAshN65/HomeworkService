namespace HomeworkMicroservice.Domain.ValueObjects.Exceptions;

public class GroupNameTooLongException : ArgumentOutOfRangeException
{
    public override string Message => $"Group name cannot be longer than {GroupName.MaxValue} characters";
}
