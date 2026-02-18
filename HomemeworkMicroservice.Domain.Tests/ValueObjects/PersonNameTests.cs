using FluentAssertions;
using HomemeworkMicroservice.Domain.Tests.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;

namespace HomemeworkMicroservice.Domain.Tests.ValueObjects;

public class PersonNameTests : BaseValueObjectTests<PersonName, string>
{
    protected override PersonName[] ValuePool => [
        new PersonName("First"),
        new PersonName("Second")
        ];

    [Fact]
    public void PersonNameIsNullItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        string name = null;

        //act
        var action = () => new PersonName(name);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    [Fact]
    public void GroupNameIsEmptyItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        var name = string.Empty;

        //act
        var action = () => new PersonName(name);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    protected override PersonName CloneValueObject(PersonName prototype)
    {
        return new PersonName((string)prototype.Value.Clone());
    }
}
