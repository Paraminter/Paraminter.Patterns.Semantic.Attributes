namespace Attribinter.Patterns.Semantic.SByteArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new SByteArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ISByteArgumentPatternFactory Sut;

        public FactoryFixture(ISByteArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        ISByteArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
