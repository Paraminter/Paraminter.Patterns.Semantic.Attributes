namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class SByte
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.SByteMock.Object, result);
    }

    private ISByteArgumentPatternFactory Target() => Fixture.Sut.SByte;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
