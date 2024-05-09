namespace Paraminter.Patterns.Semantic.Attributes.StringArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class NonNullable
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.NonNullableMock.Object, result);
    }

    private INonNullableStringArgumentPatternFactory Target() => Fixture.Sut.NonNullable;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
