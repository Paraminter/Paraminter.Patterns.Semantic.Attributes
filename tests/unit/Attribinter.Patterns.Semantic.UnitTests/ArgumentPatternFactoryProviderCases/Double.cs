namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Double
{
    private static IDoubleArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.Double;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Double, actual);
    }
}
