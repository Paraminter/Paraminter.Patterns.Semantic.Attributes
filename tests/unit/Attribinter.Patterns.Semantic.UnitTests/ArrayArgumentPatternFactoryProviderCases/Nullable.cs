namespace Attribinter.Patterns.Semantic.ArrayArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    private static INullableArrayArgumentPatternFactory Target(IArrayArgumentPatternFactoryProvider provider) => provider.Nullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Nullable, actual);
    }
}
