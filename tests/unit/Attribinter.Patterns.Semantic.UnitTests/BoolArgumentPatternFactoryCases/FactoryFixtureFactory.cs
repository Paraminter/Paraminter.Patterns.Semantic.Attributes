namespace Attribinter.Patterns.Semantic.BoolArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new BoolArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IBoolArgumentPatternFactory Sut;

        public FactoryFixture(IBoolArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IBoolArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
