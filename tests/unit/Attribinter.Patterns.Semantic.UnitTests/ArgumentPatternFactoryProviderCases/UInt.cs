namespace Attribinter.Patterns.Semantic.ArgumentPatternFactoryProviderCases;

using Xunit;

public sealed class UInt
{
    [Fact]
    public void ReturnsSameAsConstructedWith()
    {
        var result = Target();

        Assert.Same(Fixture.UIntMock.Object, result);
    }

    private IUIntArgumentPatternFactory Target() => Fixture.Sut.UInt;

    private readonly IProviderFixture Fixture = ProviderFixtureFactory.Create();
}
