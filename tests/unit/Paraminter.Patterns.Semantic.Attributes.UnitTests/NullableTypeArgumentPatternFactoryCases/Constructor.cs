namespace Paraminter.Patterns.Semantic.Attributes.NullableTypeArgumentPatternFactoryCases;

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
        var result = Record.Exception(() => Target(Mock.Of<INonNullableTypeArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<INonNullableTypeArgumentPatternFactory>(), Mock.Of<IArgumentPatternMatchResultFactoryProvider>());

        Assert.NotNull(result);
    }

    private static NullableTypeArgumentPatternFactory Target(
        INonNullableTypeArgumentPatternFactory nonNullablePatternFactory,
        IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        return new NullableTypeArgumentPatternFactory(nonNullablePatternFactory, matchResultFactoryProvider);
    }
}
