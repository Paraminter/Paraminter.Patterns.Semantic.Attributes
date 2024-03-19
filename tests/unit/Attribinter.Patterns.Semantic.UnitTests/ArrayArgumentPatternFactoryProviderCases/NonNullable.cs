namespace Attribinter.Patterns.Semantic.ArrayArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    private static INonNullableArrayArgumentPatternFactory Target(IArrayArgumentPatternFactoryProvider provider) => provider.NonNullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.NonNullable, actual);
    }
}
