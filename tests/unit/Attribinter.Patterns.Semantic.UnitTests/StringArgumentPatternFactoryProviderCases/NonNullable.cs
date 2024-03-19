namespace Attribinter.Patterns.Semantic.StringArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    private static INonNullableStringArgumentPatternFactory Target(IStringArgumentPatternFactoryProvider provider) => provider.NonNullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.NonNullable, actual);
    }
}
