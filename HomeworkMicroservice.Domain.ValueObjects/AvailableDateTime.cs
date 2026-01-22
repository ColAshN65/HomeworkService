using HomeworkMicroservice.Domain.ValueObjects.Base;
using System.Xml.Linq;

namespace HomeworkMicroservice.Domain.ValueObjects;

public class AvailableDateTime : ValueObject
{
    public DateTime DateTime { get; }

    public AvailableDateTime(DateTime dateTime)
    {
        if (dateTime > DateTime.Now.AddYears(1))
            throw new ArgumentException("The date value is too late", nameof(dateTime));

        if (dateTime.Year < 2024)
            throw new ArgumentException("The date value is too early", nameof(dateTime));

        DateTime = dateTime;
    }

    public override bool Equals(ValueObject? other)
    {
        if (other is AvailableDateTime availableDateTime)
            return DateTime.Equals(availableDateTime.DateTime);

        return false;
    }
}
