namespace Paraminter.Patterns.Semantic.Attributes.DoubleArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Create
{
    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void ReturnsPattern()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IArgumentPattern<TypedConstant, double> Target() => Fixture.Sut.Create();
}
