namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Type
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsProvider()
    {
        var result = Target();

        Assert.Same(Fixture.TypeMock.Object, result);
    }

    private ITypeArgumentPatternFactoryProvider Target() => Fixture.Sut.Type;
}
