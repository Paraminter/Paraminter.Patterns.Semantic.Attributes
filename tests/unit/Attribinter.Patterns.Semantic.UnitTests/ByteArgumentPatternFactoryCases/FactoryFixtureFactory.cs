namespace Attribinter.Patterns.Semantic.ByteArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new ByteArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IByteArgumentPatternFactory Sut;

        public FactoryFixture(IByteArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IByteArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
