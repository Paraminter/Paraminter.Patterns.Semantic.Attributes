namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Int
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.IntMock.Object, result);
    }

    private IIntArgumentPatternFactory Target() => Fixture.Sut.Int;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
