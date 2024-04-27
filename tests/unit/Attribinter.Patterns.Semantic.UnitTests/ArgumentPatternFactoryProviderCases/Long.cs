namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Long
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.LongMock.Object, result);
    }

    private ILongArgumentPatternFactory Target() => Fixture.Sut.Long;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
