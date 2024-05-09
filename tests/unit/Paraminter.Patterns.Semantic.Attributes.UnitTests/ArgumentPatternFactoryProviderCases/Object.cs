namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Object
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ObjectMock.Object, result);
    }

    private IObjectArgumentPatternFactoryProvider Target() => Fixture.Sut.Object;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
