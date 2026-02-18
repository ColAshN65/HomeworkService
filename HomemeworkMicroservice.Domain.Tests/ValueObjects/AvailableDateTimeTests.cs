using FluentAssertions;
using HomemeworkMicroservice.Domain.Tests.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;

namespace HomemeworkMicroservice.Domain.Tests.ValueObjects;

public class AvailableDateTimeTests : BaseValueObjectTests<AvailableDateTime, DateTime>
{
    protected override AvailableDateTime[] ValuePool => [
        new AvailableDateTime(DateTime.Now),
        new AvailableDateTime(DateTime.Now.AddMonths(1))
    ];

    [Fact]
    public void JesusBirthdayShouldThrowUnrealDateTimeException()
    {
        //arrange
        var date = DateTime.MinValue;
        
        //act
        var action = () => new AvailableDateTime(date);

        //arrange
        action.Should().ThrowExactly<UnrealDateTimeException>();
    }

    [Fact]
    public void FutureDateInThirteeMonthsAwayShouldThrowUnrealDateTimeException()
    {
        //arrange
        var date = DateTime.Now.AddMonths(13);

        //act
        var action = () => new AvailableDateTime(date);

        //arrange
        action.Should().ThrowExactly<UnrealDateTimeException>();
    }

    [Fact]
    public void FutureDateInElevenMonthsAwayShouldNotThrowUnrealDateTimeException()
    {
        //arrange
        var date = DateTime.Now.AddMonths(11);

        //act
        var action = () => new AvailableDateTime(date);

        //arrange
        action.Should().NotThrow<UnrealDateTimeException>();
    }

    [Fact]
    public void BegginingOfTweintyTwentyfourShouldNotThrowUnrealDateTimeException()
    {
        //arrange
        var date = new DateTime(2024, 1, 1);

        //act
        var action = () => new AvailableDateTime(date);

        //arrange
        action.Should().NotThrow<UnrealDateTimeException>();
    }

    protected override AvailableDateTime CloneValueObject(AvailableDateTime prototype)
        => new (prototype.Value);
}
