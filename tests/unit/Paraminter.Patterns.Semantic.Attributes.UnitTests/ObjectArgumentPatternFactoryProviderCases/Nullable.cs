namespace Paraminter.Patterns.Semantic.Attributes.ObjectArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.Same(Fixture.NullableMock.Object, result);
    }

    private INullableObjectArgumentPatternFactory Target() => Fixture.Sut.Nullable;
}
