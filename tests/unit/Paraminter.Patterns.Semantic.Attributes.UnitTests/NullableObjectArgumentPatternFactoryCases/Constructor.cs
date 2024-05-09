namespace Paraminter.Patterns.Semantic.Attributes.NullableObjectArgumentPatternFactoryCases;

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
        var result = Record.Exception(() => Target(Mock.Of<INonNullableObjectArgumentPatternFactory>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<INonNullableObjectArgumentPatternFactory>(), Mock.Of<IArgumentPatternMatchResultFactoryProvider>());

        Assert.NotNull(result);
    }

    private static NullableObjectArgumentPatternFactory Target(INonNullableObjectArgumentPatternFactory nonNullablePatternFactory, IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider) => new(nonNullablePatternFactory, matchResultFactoryProvider);
}
