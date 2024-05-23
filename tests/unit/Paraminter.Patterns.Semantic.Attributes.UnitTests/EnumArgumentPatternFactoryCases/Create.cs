namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using System;

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

    private IArgumentPattern<TypedConstant, StringComparison> Target() => Fixture.Sut.Create<StringComparison>();
}
