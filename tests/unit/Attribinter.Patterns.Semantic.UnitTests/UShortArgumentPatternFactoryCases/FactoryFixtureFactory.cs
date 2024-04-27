namespace Attribinter.Patterns.Semantic.UShortArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new UShortArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IUShortArgumentPatternFactory Sut;

        public FactoryFixture(IUShortArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IUShortArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
