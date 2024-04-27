namespace Attribinter.Patterns.Semantic.NonNullableArrayArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

public sealed class Create
{
    [Fact]
    public void NullElementPattern_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidElementPattern_ReturnsPattern()
    {
        var result = Target(Mock.Of<IArgumentPattern<TypedConstant, object>>());

        Assert.NotNull(result);
    }

    private IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> Target<TElement>(IArgumentPattern<TypedConstant, TElement> elementPattern) => Fixture.Sut.Create(elementPattern);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();
}
