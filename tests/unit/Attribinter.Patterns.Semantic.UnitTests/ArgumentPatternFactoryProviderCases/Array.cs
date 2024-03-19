namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Array
{
    private static IArrayArgumentPatternFactoryProvider Target(IArgumentPatternFactoryProvider provider) => provider.Array;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Array, actual);
    }
}
