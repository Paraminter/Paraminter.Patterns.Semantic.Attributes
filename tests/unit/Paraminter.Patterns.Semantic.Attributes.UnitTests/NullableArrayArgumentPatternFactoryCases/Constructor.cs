namespace Paraminter.Patterns.Semantic.Attributes.NullableArrayArgumentPatternFactoryCases;

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
        var result = Record.Exception(() => Target(Mock.Of<INonNullableArrayArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<INonNullableArrayArgumentPatternFactory>(), Mock.Of<IArgumentPatternMatchResultFactoryProvider>());

        Assert.NotNull(result);
    }

    private static NullableArrayArgumentPatternFactory Target(
        INonNullableArrayArgumentPatternFactory nonNullablePatternFactory,
        IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        return new NullableArrayArgumentPatternFactory(nonNullablePatternFactory, matchResultFactoryProvider);
    }
}
