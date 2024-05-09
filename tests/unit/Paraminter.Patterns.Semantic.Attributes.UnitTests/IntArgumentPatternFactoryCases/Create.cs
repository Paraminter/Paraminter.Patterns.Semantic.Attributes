namespace Paraminter.Patterns.Semantic.Attributes.IntArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Create
{
    [Fact]
    public void ReturnsPattern()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IArgumentPattern<TypedConstant, int> Target() => Fixture.Sut.Create();

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();
}
