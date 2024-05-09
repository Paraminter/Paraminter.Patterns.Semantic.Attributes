namespace Paraminter.Patterns.Semantic.Attributes.ByteArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        ByteArgumentPatternFactory sut = new(matchResultFactoryProviderMock.Object);

        return new FactoryFixture(sut, matchResultFactoryProviderMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IByteArgumentPatternFactory Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public FactoryFixture(IByteArgumentPatternFactory sut, Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IByteArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IFactoryFixture.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
