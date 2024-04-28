namespace Attribinter.Patterns.Semantic.NonNullableObjectArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create() => new FactoryFixture(new NonNullableObjectArgumentPatternFactory());

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INonNullableObjectArgumentPatternFactory Sut;

        public FactoryFixture(INonNullableObjectArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        INonNullableObjectArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
