namespace Attribinter.Patterns.Semantic.TypeArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    private static INullableTypeArgumentPatternFactory Target(ITypeArgumentPatternFactoryProvider provider) => provider.Nullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Nullable, actual);
    }
}
