namespace Paraminter.Patterns.Semantic.Attributes.TypeArgumentPatternFactoryProviderCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullNonNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<INullableTypeArgumentPatternFactory>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<INonNullableTypeArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<INonNullableTypeArgumentPatternFactory>(), Mock.Of<INullableTypeArgumentPatternFactory>());

        Assert.NotNull(result);
    }

    private static TypeArgumentPatternFactoryProvider Target(INonNullableTypeArgumentPatternFactory nonNullable, INullableTypeArgumentPatternFactory nullable) => new(nonNullable, nullable);
}
