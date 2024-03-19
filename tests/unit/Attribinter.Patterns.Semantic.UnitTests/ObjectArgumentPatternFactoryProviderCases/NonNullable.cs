namespace Attribinter.Patterns.Semantic.ObjectArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    private static INonNullableObjectArgumentPatternFactory Target(IObjectArgumentPatternFactoryProvider provider) => provider.NonNullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.NonNullable, actual);
    }
}
