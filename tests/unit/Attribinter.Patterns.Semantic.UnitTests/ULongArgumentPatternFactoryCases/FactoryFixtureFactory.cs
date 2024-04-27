namespace Attribinter.Patterns.Semantic.ULongArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new ULongArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IULongArgumentPatternFactory Sut;

        public FactoryFixture(IULongArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IULongArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
