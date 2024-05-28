namespace Paraminter.Patterns.Semantic.Attributes.ULongArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        ULongArgumentPatternFactory sut = new(matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture
        : IFactoryFixture
    {
        private readonly IULongArgumentPatternFactory Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(
            IULongArgumentPatternFactory sut,
            Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IULongArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
