namespace Attribinter.Patterns.Semantic.NonNullableArrayArgumentPatternFactoryCases;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        NonNullableArrayArgumentPatternFactory sut = new();

        return new FactoryFixture(sut);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INonNullableArrayArgumentPatternFactory Sut;

        public FactoryFixture(INonNullableArrayArgumentPatternFactory sut)
        {
            Sut = sut;
        }

        INonNullableArrayArgumentPatternFactory IFactoryFixture.Sut => Sut;
    }
}
