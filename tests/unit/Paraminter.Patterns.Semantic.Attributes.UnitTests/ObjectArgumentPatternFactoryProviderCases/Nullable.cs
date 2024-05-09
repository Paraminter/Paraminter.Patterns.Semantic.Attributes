namespace Paraminter.Patterns.Semantic.Attributes.ObjectArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.NullableMock.Object, result);
    }

    private INullableObjectArgumentPatternFactory Target() => Fixture.Sut.Nullable;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
