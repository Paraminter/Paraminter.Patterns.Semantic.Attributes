namespace Attribinter.Patterns.Semantic.DoubleArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new DoubleArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IDoubleArgumentPatternFactory Sut;

        public FactoryFixture(IDoubleArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IDoubleArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
