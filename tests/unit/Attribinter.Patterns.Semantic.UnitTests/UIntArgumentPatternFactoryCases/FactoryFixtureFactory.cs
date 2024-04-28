namespace Attribinter.Patterns.Semantic.UIntArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new UIntArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IUIntArgumentPatternFactory Sut;

        public FactoryFixture(IUIntArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IUIntArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
