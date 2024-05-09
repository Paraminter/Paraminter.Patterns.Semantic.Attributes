namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Array
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ArrayMock.Object, result);
    }

    private IArrayArgumentPatternFactoryProvider Target() => Fixture.Sut.Array;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
