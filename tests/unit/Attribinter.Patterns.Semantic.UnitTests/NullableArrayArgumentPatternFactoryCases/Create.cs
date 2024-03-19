namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

public sealed class Create
{
    private static IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> Target<TElement>(INullableArrayArgumentPatternFactory factory, IArgumentPattern<TypedConstant, TElement> elementPattern) => factory.Create(elementPattern);

    private static readonly FactoryContext Context = FactoryContext.Create();

    [Fact]
    public void NullElementPattern_ThrowsArgumentNullException()
    {
        var exception = Record.Exception(() => Target<object>(Context.Factory, null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void ValidElementPattern_ReturnsNotNull()
    {
        var elementPattern = Mock.Of<IArgumentPattern<TypedConstant, object>>();

        var actual = Target(Context.Factory, elementPattern);

        Assert.NotNull(actual);

        Context.NonNullablePatternFactoryMock.Verify((factory) => factory.Create(elementPattern), Times.Once());
        Context.NonNullablePatternFactoryMock.VerifyNoOtherCalls();
    }
}
