namespace Paraminter.Patterns.Semantic.Attributes.StringArgumentPatternFactoryProviderCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullNonNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<INullableStringArgumentPatternFactory>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullNullable_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<INonNullableStringArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<INonNullableStringArgumentPatternFactory>(), Mock.Of<INullableStringArgumentPatternFactory>());

        Assert.NotNull(result);
    }

    private static StringArgumentPatternFactoryProvider Target(
        INonNullableStringArgumentPatternFactory nonNullable,
        INullableStringArgumentPatternFactory nullable)
    {
        return new StringArgumentPatternFactoryProvider(nonNullable, nullable);
    }
}
