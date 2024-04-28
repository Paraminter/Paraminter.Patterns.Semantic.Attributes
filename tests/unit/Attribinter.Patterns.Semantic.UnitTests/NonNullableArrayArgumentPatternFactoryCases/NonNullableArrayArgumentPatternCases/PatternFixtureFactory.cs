namespace Attribinter.Patterns.Semantic.NonNullableArrayArgumentPatternFactoryCases.NonNullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<TElement> Create<TElement>()
    {
        Mock<IArgumentPattern<TypedConstant, TElement>> elementPatternMock = new() { DefaultValue = DefaultValue.Mock };

        var sut = ((INonNullableArrayArgumentPatternFactory)new NonNullableArrayArgumentPatternFactory()).Create(elementPatternMock.Object);

        return new PatternFixture<TElement>(sut, elementPatternMock);
    }

    private sealed class PatternFixture<TElement> : IPatternFixture<TElement>
    {
        private readonly IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, TElement>> ElementPatternMock;

        public PatternFixture(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> sut, Mock<IArgumentPattern<TypedConstant, TElement>> elementPatternMock)
        {
            Sut = sut;

            ElementPatternMock = elementPatternMock;
        }

        IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> IPatternFixture<TElement>.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, TElement>> IPatternFixture<TElement>.ElementPatternMock => ElementPatternMock;
    }
}
