using FluentAssertions;
using HomeworkMicroservice.Domain.Entities.Base;
using HomeworkMicroservice.Domain.Entities.Base.Exceptions;

namespace HomemeworkMicroservice.Domain.Tests.Entities.Base;

public abstract class BasePersonEntityTests<TEntity> : BaseEntityTests<TEntity>
    where TEntity : Person
{
    protected abstract TEntity CreatePersonWithNullName();

    [Fact]
    public void PersonWithNullNameShouldThrowPersonFullNameNullException()
    {
        //act
        var action = () => { CreatePersonWithNullName(); };

        //assert
        action.Should().ThrowExactly<PersonFullNameNullException>();
    }
}
