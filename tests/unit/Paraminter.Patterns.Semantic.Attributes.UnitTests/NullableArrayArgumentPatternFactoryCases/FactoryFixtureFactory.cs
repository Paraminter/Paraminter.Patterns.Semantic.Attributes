namespace Paraminter.Patterns.Semantic.Attributes.NullableArrayArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        NullableArrayArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object, matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INullableArrayArgumentPatternFactory Sut;

        private readonly Mock<INonNullableArrayArgumentPatternFactory> NonNullablePatternFactoryMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(INullableArrayArgumentPatternFactory sut, Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        INullableArrayArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableArrayArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
