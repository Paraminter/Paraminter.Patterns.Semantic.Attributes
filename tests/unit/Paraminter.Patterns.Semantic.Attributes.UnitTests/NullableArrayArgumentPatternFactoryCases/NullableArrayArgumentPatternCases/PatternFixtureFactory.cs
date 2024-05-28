namespace Paraminter.Patterns.Semantic.Attributes.NullableArrayArgumentPatternFactoryCases.NullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<TElement> Create<TElement>()
    {
        Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> nonNullablePatternMock = new();

        Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create(It.IsAny<IArgumentPattern<TypedConstant, TElement>>())).Returns(nonNullablePatternMock.Object);

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        INullableArrayArgumentPatternFactory nullablePatternFactory = new NullableArrayArgumentPatternFactory(nonNullablePatternFactoryMock.Object, matchResultFactoryProviderMock.Object);

        var sut = nullablePatternFactory.Create(Mock.Of<IArgumentPattern<TypedConstant, TElement>>());

        return new PatternFixture<TElement>(sut, nonNullablePatternMock, matchResultFactoryProviderMock);
    }

    private sealed class PatternFixture<TElement>
        : IPatternFixture<TElement>
    {
        private readonly IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> NonNullablePatternMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public PatternFixture(
            IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> sut,
            Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> nonNullablePatternMock,
            Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            NonNullablePatternMock = nonNullablePatternMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> IPatternFixture<TElement>.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> IPatternFixture<TElement>.NonNullablePatternMock => NonNullablePatternMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IPatternFixture<TElement>.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
