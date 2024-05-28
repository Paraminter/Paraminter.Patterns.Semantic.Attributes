namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArrayArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        NonNullableArrayArgumentPatternFactory sut = new(matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly INonNullableArrayArgumentPatternFactory Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(
            INonNullableArrayArgumentPatternFactory sut,
            Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        INonNullableArrayArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
