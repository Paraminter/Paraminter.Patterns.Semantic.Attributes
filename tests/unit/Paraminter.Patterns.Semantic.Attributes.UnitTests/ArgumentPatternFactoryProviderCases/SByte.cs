namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class SByte
{
    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();

    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.SByteMock.Object, result);
    }

    private ISByteArgumentPatternFactory Target() => Fixture.Sut.SByte;
}
