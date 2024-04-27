namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Char
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.CharMock.Object, result);
    }

    private ICharArgumentPatternFactory Target() => Fixture.Sut.Char;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
