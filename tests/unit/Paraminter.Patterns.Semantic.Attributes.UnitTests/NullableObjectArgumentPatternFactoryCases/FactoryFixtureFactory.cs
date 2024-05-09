namespace Paraminter.Patterns.Semantic.Attributes.NullableObjectArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        NullableObjectArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object, matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INullableObjectArgumentPatternFactory Sut;

        private readonly Mock<INonNullableObjectArgumentPatternFactory> NonNullablePatternFactoryMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(INullableObjectArgumentPatternFactory sut, Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        INullableObjectArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableObjectArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
