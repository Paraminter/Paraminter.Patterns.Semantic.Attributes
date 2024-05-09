namespace Paraminter.Patterns.Semantic.Attributes.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class Enum
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.EnumMock.Object, result);
    }

    private IEnumArgumentPatternFactory Target() => Fixture.Sut.Enum;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
