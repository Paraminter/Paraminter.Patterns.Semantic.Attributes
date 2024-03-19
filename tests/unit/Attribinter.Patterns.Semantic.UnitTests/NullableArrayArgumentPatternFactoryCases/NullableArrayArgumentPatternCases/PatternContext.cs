namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases.NullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal sealed class PatternContext<TElement>
{
    public static PatternContext<TElement> Create()
    {
        Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> nonNullablePatternMock = new() { DefaultValue = DefaultValue.Mock };

        Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create(It.IsAny<IArgumentPattern<TypedConstant, TElement>>())).Returns(nonNullablePatternMock.Object);

        INullableArrayArgumentPatternFactory nullablePatternFactory = new NullableArrayArgumentPatternFactory(nonNullablePatternFactoryMock.Object);

        var pattern = nullablePatternFactory.Create(Mock.Of<IArgumentPattern<TypedConstant, TElement>>());

        return new(pattern, nonNullablePatternMock);
    }

    public IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> Pattern { get; }

    public Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> NonNullablePatternMock { get; }

    private PatternContext(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> pattern, Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> nonNullablePatternMock)
    {
        Pattern = pattern;

        NonNullablePatternMock = nonNullablePatternMock;
    }
}
