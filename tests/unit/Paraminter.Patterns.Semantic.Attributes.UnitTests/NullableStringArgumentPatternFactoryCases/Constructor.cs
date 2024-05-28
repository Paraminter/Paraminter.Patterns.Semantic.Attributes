namespace Paraminter.Patterns.Semantic.Attributes.NullableStringArgumentPatternFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullNonNullablePatternFactory_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<IArgumentPatternMatchResultFactoryProvider>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullMatchResultFactoryProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<INonNullableStringArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<INonNullableStringArgumentPatternFactory>(), Mock.Of<IArgumentPatternMatchResultFactoryProvider>());

        Assert.NotNull(result);
    }

    private static NullableStringArgumentPatternFactory Target(
        INonNullableStringArgumentPatternFactory nonNullablePatternFactory,
        IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        return new NullableStringArgumentPatternFactory(nonNullablePatternFactory, matchResultFactoryProvider);
    }
}
