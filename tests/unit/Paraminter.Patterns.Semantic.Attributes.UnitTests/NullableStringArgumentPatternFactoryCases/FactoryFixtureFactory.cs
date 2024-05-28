namespace Paraminter.Patterns.Semantic.Attributes.NullableStringArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        NullableStringArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object, matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly INullableStringArgumentPatternFactory Sut;

        private readonly Mock<INonNullableStringArgumentPatternFactory> NonNullablePatternFactoryMock;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(
            INullableStringArgumentPatternFactory sut,
            Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock,
            Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        INullableStringArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableStringArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
