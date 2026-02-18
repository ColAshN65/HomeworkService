using HomeworkMicroservice.Domain.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;
using System.Xml.Linq;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class AvailableDateTime : ValueObject<DateTime>
{
    public override DateTime Value { get; }

    /// <exception cref="UnrealDateTimeException"></exception>
    public AvailableDateTime(DateTime dateTime)
    {
        if (dateTime > DateTime.Now.AddYears(1))
            throw new UnrealDateTimeException();

        if (dateTime.Year < 2024)
            throw new UnrealDateTimeException();

        Value = dateTime;
    }


    public override bool Equals(IValueObject? other)
    {
        if (other is AvailableDateTime availableDateTime)
            return Value.Equals(availableDateTime.Value);

        return false;
    }
}
