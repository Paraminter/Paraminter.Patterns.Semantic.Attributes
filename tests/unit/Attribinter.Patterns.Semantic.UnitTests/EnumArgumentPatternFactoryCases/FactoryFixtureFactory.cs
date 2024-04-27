namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new EnumArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IEnumArgumentPatternFactory Sut;

        public FactoryFixture(IEnumArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IEnumArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
