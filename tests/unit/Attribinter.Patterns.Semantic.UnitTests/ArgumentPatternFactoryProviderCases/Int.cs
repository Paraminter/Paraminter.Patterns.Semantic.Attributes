namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Int
{
    private static IIntArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.Int;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Int, actual);
    }
}
