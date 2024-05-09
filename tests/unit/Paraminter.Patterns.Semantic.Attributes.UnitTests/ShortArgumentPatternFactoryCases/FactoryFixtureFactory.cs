namespace Paraminter.Patterns.Semantic.Attributes.ShortArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        ShortArgumentPatternFactory sut = new(matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IShortArgumentPatternFactory Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(IShortArgumentPatternFactory sut, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IShortArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
