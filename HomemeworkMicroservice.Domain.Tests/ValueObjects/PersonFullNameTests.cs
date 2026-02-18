using FluentAssertions;
using HomemeworkMicroservice.Domain.Tests.ValueObjects.Base;
using HomeworkMicroservice.Domain.ValueObjects;
using HomeworkMicroservice.Domain.ValueObjects.Exceptions;

namespace HomemeworkMicroservice.Domain.Tests.ValueObjects;

public class PersonFullNameTests : BaseValueObjectTests<PersonFullName, string>
{
    protected override PersonFullName[] ValuePool => [
        new PersonFullName("Michael", "Zubenko", "Petrovich"),
        new PersonFullName("Da", "Da", "Da")
        ];

    [Fact]
    public void FirstNameIsNullItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        string firstName = null;
        string lastName = "Zubenko";
        string patronymic = "Petrovich";

        //act
        var action = () => new PersonFullName(firstName, lastName, patronymic);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    [Fact]
    public void FirstNameIsEmptyItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        string firstName = string.Empty;
        string lastName = "Zubenko";
        string patronymic = "Petrovich";

        //act
        var action = () => new PersonFullName(firstName, lastName, patronymic);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    [Fact]
    public void LastNameIsNullItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        string firstName = "Michael";
        string lastName = null;
        string patronymic = "Petrovich";

        //act
        var action = () => new PersonFullName(firstName, lastName, patronymic);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    [Fact]
    public void LastNameIsEmptyItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        string firstName = "Michael";
        string lastName = string.Empty;
        string patronymic = "Petrovich";

        //act
        var action = () => new PersonFullName(firstName, lastName, patronymic);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    [Fact]
    public void PatronymicIsNullItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        string firstName = "Michael";
        string lastName = "Zubenko";
        string patronymic = null;

        //act
        var action = () => new PersonFullName(firstName, lastName, patronymic);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    [Fact]
    public void PatronymicIsEmptyItsShouldThrowPersonNameNullOrEmptyException()
    {
        //arrange
        string firstName = "Michael";
        string lastName = "Zubenko";
        string patronymic = string.Empty;

        //act
        var action = () => new PersonFullName(firstName, lastName, patronymic);

        //arrange
        action.Should().ThrowExactly<PersonNameNullOrEmptyException>();
    }

    protected override PersonFullName CloneValueObject(PersonFullName prototype)
        => new (prototype.FirstName, prototype.Surname, prototype.Patronymic);
}
