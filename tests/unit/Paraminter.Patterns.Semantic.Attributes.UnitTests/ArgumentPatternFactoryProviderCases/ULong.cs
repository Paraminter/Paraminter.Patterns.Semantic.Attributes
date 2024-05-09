namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class ULong
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ULongMock.Object, result);
    }

    private IULongArgumentPatternFactory Target() => Fixture.Sut.ULong;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
