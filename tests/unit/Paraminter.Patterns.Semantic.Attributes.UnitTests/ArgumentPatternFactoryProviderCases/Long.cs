namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Long
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.LongMock.Object, result);
    }

    private ILongArgumentPatternFactory Target() => Fixture.Sut.Long;
}
