namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Short
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ShortMock.Object, result);
    }

    private IShortArgumentPatternFactory Target() => Fixture.Sut.Short;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
