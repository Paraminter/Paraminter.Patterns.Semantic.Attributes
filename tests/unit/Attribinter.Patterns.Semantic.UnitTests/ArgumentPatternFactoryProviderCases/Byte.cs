namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Byte
{
    private static IByteArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.Byte;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Byte, actual);
    }
}
