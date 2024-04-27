namespace Attribinter.Patterns.Semantic.NonNullableStringArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new NonNullableStringArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INonNullableStringArgumentPatternFactory Sut;

        public FactoryFixture(INonNullableStringArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        INonNullableStringArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
