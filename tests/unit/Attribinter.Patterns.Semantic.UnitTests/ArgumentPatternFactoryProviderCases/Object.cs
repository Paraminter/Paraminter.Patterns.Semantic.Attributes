namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Object
{
    private static IObjectArgumentPatternFactoryProvider Target(IArgumentPatternFactoryProvider provider) => provider.Object;

    private static readonly ProviderContext Context = ProviderContext.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var actual = Target(Context.Provider);

        Assert.Same(Context.Object, actual);
    }
}
