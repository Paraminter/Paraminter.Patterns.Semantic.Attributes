namespace Paraminter.Patterns.Semantic.Attributes.StringArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.NullableMock.Object, result);
    }

    private INullableStringArgumentPatternFactory Target() => Fixture.Sut.Nullable;
}
