namespace Attribinter.Patterns.Semantic.StringArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    private static INullableStringArgumentPatternFactory Target(IStringArgumentPatternFactoryProvider provider) => provider.Nullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Nullable, actual);
    }
}
