namespace Paraminter.Patterns.Semantic.Attributes.ObjectArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.Same(Fixture.NonNullableMock.Object, result);
    }

    private INonNullableObjectArgumentPatternFactory Target() => Fixture.Sut.NonNullable;
}
