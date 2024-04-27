namespace Attribinter.Patterns.Semantic.CharArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new CharArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ICharArgumentPatternFactory Sut;

        public FactoryFixture(ICharArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        ICharArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
