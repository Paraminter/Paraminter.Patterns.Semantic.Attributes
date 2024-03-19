namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Bool
{
    private static IBoolArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.Bool;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Bool, actual);
    }
}
