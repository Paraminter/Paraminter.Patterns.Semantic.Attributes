namespace Paraminter.Patterns.Semantic.Attributes.NonNullableObjectArgumentPatternFactoryCases.NonNullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        INonNullableObjectArgumentPatternFactory factory = new NonNullableObjectArgumentPatternFactory(matchResultFactoryProviderMock.Object);

        var sut = factory.Create();

        return new PatternFixture(sut, matchResultFactoryProviderMock);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, object> Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public PatternFixture(IArgumentPattern<TypedConstant, object> sut, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IArgumentPattern<TypedConstant, object> IPatternFixture.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IPatternFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
