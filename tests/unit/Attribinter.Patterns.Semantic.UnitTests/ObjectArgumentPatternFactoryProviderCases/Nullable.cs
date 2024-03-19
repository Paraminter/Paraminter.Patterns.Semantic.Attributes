namespace Attribinter.Patterns.Semantic.ObjectArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    private static INullableObjectArgumentPatternFactory Target(IObjectArgumentPatternFactoryProvider provider) => provider.Nullable;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Nullable, actual);
    }
}
