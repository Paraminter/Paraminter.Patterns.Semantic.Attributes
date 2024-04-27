namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using System;

using Xunit;

public sealed class Create
{
    [Fact]
    public void ReturnsPattern()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private IArgumentPattern<TypedConstant, StringComparison> Target() => Fixture.Sut.Create<StringComparison>();

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();
}
