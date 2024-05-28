namespace Paraminter.Patterns.Semantic.Attributes.NullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<string> CreateString()
    {
        return Create<string>(createPattern);

        static IArgumentPattern<TypedConstant, string?> createPattern(
            IArgumentPattern<TypedConstant, string> nonNullablePattern,
            IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock = new();

            nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePattern);

            INullableStringArgumentPatternFactory factory = new NullableStringArgumentPatternFactory(nonNullablePatternFactoryMock.Object, matchResultFactoryProvider);

            return factory.Create();
        }
    }

    public static IPatternFixture<ITypeSymbol> CreateType()
    {
        return Create<ITypeSymbol>(createPattern);

        static IArgumentPattern<TypedConstant, ITypeSymbol?> createPattern(
            IArgumentPattern<TypedConstant, ITypeSymbol> nonNullablePattern,
            IArgumentPatternMatchResultFactoryProvider matchResultFactoryProvider)
        {
            Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock = new();

            nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePattern);

            INullableTypeArgumentPatternFactory factory = new NullableTypeArgumentPatternFactory(nonNullablePatternFactoryMock.Object, matchResultFactoryProvider);

            return factory.Create();
        }
    }

    private static PatternFixture<TOut> Create<TOut>(
        Func<IArgumentPattern<TypedConstant, TOut>, IArgumentPatternMatchResultFactoryProvider, IArgumentPattern<TypedConstant, TOut?>> patternDelegate)
    {
        Mock<IArgumentPattern<TypedConstant, TOut>> nonNullablePatternMock = new();

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        var sut = patternDelegate(nonNullablePatternMock.Object, matchResultFactoryProviderMock.Object);

        return new PatternFixture<TOut>(sut, nonNullablePatternMock, matchResultFactoryProviderMock);
    }

    private sealed class PatternFixture<TOut>
        : IPatternFixture<TOut>
    {
        private readonly IArgumentPattern<TypedConstant, TOut?> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, TOut>> NonNullablePatternMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public PatternFixture(
            IArgumentPattern<TypedConstant, TOut?> sut,
            Mock<IArgumentPattern<TypedConstant, TOut>> nonNullablePatternMock,
            Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            NonNullablePatternMock = nonNullablePatternMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IArgumentPattern<TypedConstant, TOut?> IPatternFixture<TOut>.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, TOut>> IPatternFixture<TOut>.NonNullablePatternMock => NonNullablePatternMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IPatternFixture<TOut>.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
