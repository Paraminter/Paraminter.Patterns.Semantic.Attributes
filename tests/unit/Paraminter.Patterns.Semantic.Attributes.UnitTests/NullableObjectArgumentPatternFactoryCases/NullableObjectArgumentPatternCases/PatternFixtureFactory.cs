namespace Paraminter.Patterns.Semantic.Attributes.NullableObjectArgumentPatternFactoryCases.NullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        Mock<IArgumentPattern<TypedConstant, object>> nonNullablePatternMock = new();

        Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePatternMock.Object);

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        INullableObjectArgumentPatternFactory factory = new NullableObjectArgumentPatternFactory(nonNullablePatternFactoryMock.Object, matchResultFactoryProviderMock.Object);

        var sut = factory.Create();

        return new PatternFixture(sut, nonNullablePatternMock, matchResultFactoryProviderMock);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, object?> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, object>> NonNullablePatternMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public PatternFixture(IArgumentPattern<TypedConstant, object?> sut, Mock<IArgumentPattern<TypedConstant, object>> nonNullablePatternMock, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            NonNullablePatternMock = nonNullablePatternMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IArgumentPattern<TypedConstant, object?> IPatternFixture.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, object>> IPatternFixture.NonNullablePatternMock => NonNullablePatternMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IPatternFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
