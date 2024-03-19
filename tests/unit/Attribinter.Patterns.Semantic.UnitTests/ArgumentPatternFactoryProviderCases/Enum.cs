namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Enum
{
    private static IEnumArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.Enum;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Enum, actual);
    }
}
