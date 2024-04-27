namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Float
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.FloatMock.Object, result);
    }

    private IFloatArgumentPatternFactory Target() => Fixture.Sut.Float;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
