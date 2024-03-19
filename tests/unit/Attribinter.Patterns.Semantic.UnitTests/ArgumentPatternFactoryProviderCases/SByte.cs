namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class SByte
{
    private static ISByteArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.SByte;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.SByte, actual);
    }
}
