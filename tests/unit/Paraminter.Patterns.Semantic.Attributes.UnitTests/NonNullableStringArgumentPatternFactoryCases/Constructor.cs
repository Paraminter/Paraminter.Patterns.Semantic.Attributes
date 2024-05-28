namespace Paraminter.Patterns.Semantic.Attributes.NonNullableStringArgumentPatternFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullMatchResultFactoryProvider_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsFactory()
    {
        var result = Target(Mock.Of<IArgumentPatternMatchResultFactoryProvider>());

        Assert.NotNull(result);
    }

    private static NonNullableStringArgumentPatternFactory Target(
        IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
    {
        return new NonNullableStringArgumentPatternFactory(matchResultFactoryProvider);
    }
}
