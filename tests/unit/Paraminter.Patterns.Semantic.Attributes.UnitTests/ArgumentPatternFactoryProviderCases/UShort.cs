namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class UShort
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.UShortMock.Object, result);
    }

    private IUShortArgumentPatternFactory Target() => Fixture.Sut.UShort;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
