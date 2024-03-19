namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class ULong
{
    private static IULongArgumentPatternFactory Target(IArgumentPatternFactoryProvider provider) => provider.ULong;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.ULong, actual);
    }
}
