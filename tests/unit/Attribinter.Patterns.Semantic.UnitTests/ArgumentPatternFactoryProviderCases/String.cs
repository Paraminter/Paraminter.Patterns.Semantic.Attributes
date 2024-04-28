namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class String
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.StringMock.Object, result);
    }

    private IStringArgumentPatternFactoryProvider Target() => Fixture.Sut.String;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
