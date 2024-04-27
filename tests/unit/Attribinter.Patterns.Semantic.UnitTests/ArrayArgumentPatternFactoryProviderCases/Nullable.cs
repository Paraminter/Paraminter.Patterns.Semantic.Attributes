namespace Attribinter.Patterns.Semantic.ArrayArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Nullable
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.NullableMock.Object, result);
    }

    private INullableArrayArgumentPatternFactory Target() => Fixture.Sut.Nullable;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
