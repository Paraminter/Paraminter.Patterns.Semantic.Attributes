namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class UShort
{
    private static IUShortArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.UShort;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.UShort, actual);
    }
}
