namespace Attribinter.Patterns.Semantic.ShortArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new ShortArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IShortArgumentPatternFactory Sut;

        public FactoryFixture(IShortArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IShortArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
