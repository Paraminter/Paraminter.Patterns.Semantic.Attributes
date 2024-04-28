namespace Attribinter.Patterns.Semantic.ArrayArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.NonNullableMock.Object, result);
    }

    private INonNullableArrayArgumentPatternFactory Target() => Fixture.Sut.NonNullable;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
