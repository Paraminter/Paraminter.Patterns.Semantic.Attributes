namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Short
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ShortMock.Object, result);
    }

    private IShortArgumentPatternFactory Target() => Fixture.Sut.Short;
}
