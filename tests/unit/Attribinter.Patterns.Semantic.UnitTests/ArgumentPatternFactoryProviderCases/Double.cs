namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Double
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.DoubleMock.Object, result);
    }

    private IDoubleArgumentPatternFactory Target() => Fixture.Sut.Double;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
