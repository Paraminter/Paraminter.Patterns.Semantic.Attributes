namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Type
{
    private static ITypeArgumentPatternFactoryProvider Target(IArgumentPatternFactoryProvider provider) => provider.Type;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Type, actual);
    }
}
