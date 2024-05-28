namespace Paraminter.Patterns.Semantic.Attributes.ObjectArgumentPatternFactoryProviderCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullNonNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<INullableObjectArgumentPatternFactory>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<INonNullableObjectArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<INonNullableObjectArgumentPatternFactory>(), Mock.Of<INullableObjectArgumentPatternFactory>());

        Assert.NotNull(result);
    }

    private static ObjectArgumentPatternFactoryProvider Target(
        INonNullableObjectArgumentPatternFactory nonNullable,
        INullableObjectArgumentPatternFactory nullable)
    {
        return new ObjectArgumentPatternFactoryProvider(nonNullable, nullable);
    }
}
