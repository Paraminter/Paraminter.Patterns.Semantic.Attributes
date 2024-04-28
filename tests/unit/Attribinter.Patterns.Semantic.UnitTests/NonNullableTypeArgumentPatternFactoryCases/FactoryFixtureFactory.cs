namespace Attribinter.Patterns.Semantic.NonNullableTypeArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new NonNullableTypeArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INonNullableTypeArgumentPatternFactory Sut;

        public FactoryFixture(INonNullableTypeArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        INonNullableTypeArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
