namespace Attribinter.Patterns.Semantic.TypeArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    private static INonNullableTypeArgumentPatternFactory Target(ITypeArgumentPatternFactoryProvider provider) => provider.NonNullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.NonNullable, actual);
    }
}
