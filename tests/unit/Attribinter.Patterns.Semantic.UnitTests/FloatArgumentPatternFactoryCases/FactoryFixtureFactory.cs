namespace Attribinter.Patterns.Semantic.FloatArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new FloatArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IFloatArgumentPatternFactory Sut;

        public FactoryFixture(IFloatArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IFloatArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
