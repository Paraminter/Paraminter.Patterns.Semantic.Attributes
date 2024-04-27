namespace Attribinter.Patterns.Semantic.ObjectArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.NonNullableMock.Object, result);
    }

    private INonNullableObjectArgumentPatternFactory Target() => Fixture.Sut.NonNullable;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
