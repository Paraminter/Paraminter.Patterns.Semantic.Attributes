namespace Attribinter.Patterns.Semantic.IntArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new IntArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly IIntArgumentPatternFactory Sut;

        public FactoryFixture(IIntArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        IIntArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
