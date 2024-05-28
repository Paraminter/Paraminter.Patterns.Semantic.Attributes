namespace Paraminter.Patterns.Semantic.Attributes.NullableTypeArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        NullableTypeArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object, matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly INullableTypeArgumentPatternFactory Sut;

        private readonly Mock<INonNullableTypeArgumentPatternFactory> NonNullablePatternFactoryMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(
            INullableTypeArgumentPatternFactory sut,
            Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock,
            Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        INullableTypeArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableTypeArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
