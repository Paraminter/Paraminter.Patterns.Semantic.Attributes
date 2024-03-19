namespace Attribinter.Patterns.Semantic.NonNullableArrayArgumentPatternFactoryCases.NonNullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal sealed class PatternContext<TElement>
{
    public static PatternContext<TElement> Create()
    {
        Mock<IArgumentPattern<TypedConstant, TElement>> elementPatternMock = new() { DefaultValue = DefaultValue.Mock };

        var pattern = ((INonNullableArrayArgumentPatternFactory)new NonNullableArrayArgumentPatternFactory()).Create(elementPatternMock.Object);

        return new(pattern, elementPatternMock);
    }

    public IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> Pattern { get; }

    public Mock<IArgumentPattern<TypedConstant, TElement>> ElementPatternMock { get; }

    private PatternContext(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> pattern, Mock<IArgumentPattern<TypedConstant, TElement>> elementPatternMock)
    {
        Pattern = pattern;

        ElementPatternMock = elementPatternMock;
    }
}
