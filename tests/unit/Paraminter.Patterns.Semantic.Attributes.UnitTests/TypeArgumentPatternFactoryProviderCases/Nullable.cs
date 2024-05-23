namespace Paraminter.Patterns.Semantic.Attributes.TypeArgumentPatternFactoryProviderCases;

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

    private INullableTypeArgumentPatternFactory Target() => Fixture.Sut.Nullable;
}
