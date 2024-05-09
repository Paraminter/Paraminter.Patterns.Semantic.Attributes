namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Type
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.TypeMock.Object, result);
    }

    private ITypeArgumentPatternFactoryProvider Target() => Fixture.Sut.Type;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
