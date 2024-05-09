namespace Paraminter.Patterns.Semantic.Attributes.ArrayArgumentPatternFactoryProviderCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullNonNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<INullableArrayArgumentPatternFactory>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<INonNullableArrayArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsProvider()
    {
        var result = Target(Mock.Of<INonNullableArrayArgumentPatternFactory>(), Mock.Of<INullableArrayArgumentPatternFactory>());

        Assert.NotNull(result);
    }

    private static ArrayArgumentPatternFactoryProvider Target(INonNullableArrayArgumentPatternFactory nonNullable, INullableArrayArgumentPatternFactory nullable) => new(nonNullable, nullable);
}
