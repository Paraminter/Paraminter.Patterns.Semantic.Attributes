namespace Attribinter.Patterns.Semantic.LongArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new LongArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly ILongArgumentPatternFactory Sut;

        public FactoryFixture(ILongArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        ILongArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
