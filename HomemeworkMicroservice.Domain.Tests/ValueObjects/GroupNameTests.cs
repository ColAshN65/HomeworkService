using FluentAssertions;
using HomemeworkMicroservice.Domain.Tests.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;

namespace HomemeworkMicroservice.Domain.Tests.ValueObjects;

public class GroupNameTests : BaseValueObjectTests<GroupName, string>
{
    protected override GroupName[] ValuePool => [
        new GroupName("First"),
        new GroupName("Second")
        ];

    [Fact]
    public void GroupNameIsNullItsShouldThrowGroupNameNullOrEmptyException()
    {
        //arrange
        string name = null;

        //act
        var action = () => new GroupName(name);

        //assert
        action.Should().ThrowExactly<GroupNameNullOrEmptyException>();
    }

    [Fact]
    public void GroupNameIsEmptyItsShouldThrowGroupNameNullOrEmptyException()
    {
        //arrange
        var name = string.Empty;

        //act
        var action = () => new GroupName(name);

        //assert
        action.Should().ThrowExactly<GroupNameNullOrEmptyException>();
    }

    [Fact]
    public void IfLengthOfGroupNameIsElevenCharactersItsShouldThrowGroupNameTooLongException()
    {
        //arrange
        var name = "1234567890X";

        //act
        var action = () => new GroupName(name);

        //assert
        action.Should().ThrowExactly<GroupNameTooLongException>();
    }

    [Fact]
    public void IfLengthOfGroupNameIsOneHundreedCharactersItsShouldThrowGroupNameTooLongException()
    {
        //arrange
        var name = new string('a', 100);

        //act
        var action = () => new GroupName(name);

        //assert 
        action.Should().ThrowExactly<GroupNameTooLongException>();
    }

    protected override GroupName CloneValueObject(GroupName prototype)
    {
        return new GroupName(prototype.Value);
    }
}
