using HomeworkMicroservice.Domain.ValueObjects;
using HomeworkMicroservice.Domain.ValueObjects.Base;

namespace HomemeworkMicroservice.Domain.Tests.ValueObjects.Base;

public abstract class BaseValueObjectTests<TValueObject>
    where TValueObject : ValueObject
{
    protected abstract TValueObject[] ValuePool { get; }
    protected abstract TValueObject CloneValueObject(TValueObject prototype);

    [Fact]
    public void IfValuesOfValueObjectsEqualsItsMustBeEquals()
    {
        //arrange
        var firstValue = ValuePool[0];
        var secondValue = CloneValueObject(firstValue);

        //act
        var comparisonValueObjectsResult = firstValue == secondValue;

        //assert
        Assert.True(comparisonValueObjectsResult);
    }

    [Fact]
    public void IfValuesOfValueObjectsNotEqualsItsMustBeNotEquals()
    {
        //arrange
        var firstValue = ValuePool[0];
        var secondValue = ValuePool[1];

        //act
        var comparisonValueObjectsResult = firstValue != secondValue;

        //assert
        Assert.True(comparisonValueObjectsResult);
    }

    public abstract void IfValuesOfValueObjectsEqualsItsHashCodesMustBeEquals();
}

public abstract class BaseValueObjectTests<TValueObject, TValue> : BaseValueObjectTests<TValueObject>
    where TValueObject : ValueObject<TValue>
    where TValue : notnull
{
    [Fact]
    public override void IfValuesOfValueObjectsEqualsItsHashCodesMustBeEquals()
    {
        //arrange
        var firstValue = ValuePool[0];
        var secondValue = CloneValueObject(firstValue);

        //act
        var comprasionHasCodesResult = firstValue.GetHashCode() == secondValue.GetHashCode();

        //assert
        Assert.True(comprasionHasCodesResult);
    }
}
