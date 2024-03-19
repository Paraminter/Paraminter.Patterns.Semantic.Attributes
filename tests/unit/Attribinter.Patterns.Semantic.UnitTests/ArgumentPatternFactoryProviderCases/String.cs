namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class String
{
    private static IStringArgumentPatternFactoryProvider Target(IArgumentPatternFactoryProvider provider) => provider.String;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.String, actual);
    }
}
