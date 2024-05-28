namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class String
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsProvider()
    {
        var result = Target();

        Assert.Same(Fixture.StringMock.Object, result);
    }

    private IStringArgumentPatternFactoryProvider Target() => Fixture.Sut.String;
}
