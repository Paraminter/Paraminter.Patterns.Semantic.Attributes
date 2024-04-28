namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Bool
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.BoolMock.Object, result);
    }

    private IBoolArgumentPatternFactory Target() => Fixture.Sut.Bool;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
