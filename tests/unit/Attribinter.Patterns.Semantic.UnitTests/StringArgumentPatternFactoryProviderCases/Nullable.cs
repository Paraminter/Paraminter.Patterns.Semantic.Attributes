namespace Attribinter.Patterns.Semantic.StringArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.NullableMock.Object, result);
    }

    private INullableStringArgumentPatternFactory Target() => Fixture.Sut.Nullable;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
