namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class UInt
{
    private static IUIntArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.UInt;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.UInt, actual);
    }
}
