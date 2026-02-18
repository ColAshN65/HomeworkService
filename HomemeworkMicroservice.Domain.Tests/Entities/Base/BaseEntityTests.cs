using HomeworkMicroservice.Domain.Entities.Base;

namespace HomemeworkMicroservice.Domain.Tests.Entities.Base;

public abstract class BaseEntityTests<TEntity>
    where TEntity : EntityBase
{
    protected abstract TEntity CreateEntity();
    protected abstract TEntity CreateUpdatedEntity(TEntity entity);

    [Fact]
    public void IfEntityBaseGuidEqualsEntityBaseIsEquals()
    {
        //arrange
        var entity = CreateEntity();
        var secondEntity = CreateUpdatedEntity(entity);

        //act
        var result = entity == secondEntity;

        //assert
        Assert.True(result);
    }

    [Fact]
    public void IfEntityBaseGuidNotEqualsEntityBaseIsNotEquals()
    {
        //arrange
        var entity = CreateEntity();
        var secondEntity = CreateEntity();

        //act
        var result = entity != secondEntity;

        //assert
        Assert.True(result);
    }
}
