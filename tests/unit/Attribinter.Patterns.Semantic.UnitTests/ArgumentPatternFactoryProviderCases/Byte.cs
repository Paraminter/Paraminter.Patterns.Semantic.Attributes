namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Byte
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.ByteMock.Object, result);
    }

    private IByteArgumentPatternFactory Target() => Fixture.Sut.Byte;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
