namespace Paraminter.Patterns.Semantic.Attributes.FloatArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        FloatArgumentPatternFactory sut = new(matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IFloatArgumentPatternFactory Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(IFloatArgumentPatternFactory sut, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IFloatArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
