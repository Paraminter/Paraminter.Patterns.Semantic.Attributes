namespace Paraminter.Patterns.Semantic.Attributes.NonNullableTypeArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class Create
{
    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void RetunsPattern()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IArgumentPattern<TypedConstant, ITypeSymbol> Target() => Fixture.Sut.Create();
}
