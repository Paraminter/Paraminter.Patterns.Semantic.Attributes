namespace Paraminter.Patterns.Semantic.Attributes.NullableArrayArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

public sealed class Create
{
    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void NullElementPattern_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidElementPattern_ReturnsPattern()
    {
        var elementPattern = Mock.Of<IArgumentPattern<TypedConstant, object>>();

        var result = Target(elementPattern);

        Assert.NotNull(result);
    }

    private IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> Target<TElement>(IArgumentPattern<TypedConstant, TElement> elementPattern) => Fixture.Sut.Create(elementPattern);
}
