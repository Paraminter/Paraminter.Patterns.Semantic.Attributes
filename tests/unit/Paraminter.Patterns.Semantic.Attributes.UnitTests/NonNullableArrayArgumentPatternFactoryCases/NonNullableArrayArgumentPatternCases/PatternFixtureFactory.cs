namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArrayArgumentPatternFactoryCases.NonNullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<TElement> Create<TElement>()
    {
        Mock<IArgumentPattern<TypedConstant, TElement>> elementPatternMock = new();

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        INonNullableArrayArgumentPatternFactory factory = new NonNullableArrayArgumentPatternFactory(matchResultFactoryProviderMock.Object);

        var sut = factory.Create(elementPatternMock.Object);

        return new PatternFixture<TElement>(sut, elementPatternMock, matchResultFactoryProviderMock);
    }

    private sealed class PatternFixture<TElement> : IPatternFixture<TElement>
    {
        private readonly IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, TElement>> ElementPatternMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public PatternFixture(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> sut, Mock<IArgumentPattern<TypedConstant, TElement>> elementPatternMock, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            ElementPatternMock = elementPatternMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> IPatternFixture<TElement>.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, TElement>> IPatternFixture<TElement>.ElementPatternMock => ElementPatternMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IPatternFixture<TElement>.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
