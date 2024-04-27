namespace Attribinter.Patterns.Semantic.NullableStringArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableStringArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INullableStringArgumentPatternFactory Sut;

        private readonly Mock<INonNullableStringArgumentPatternFactory> NonNullablePatternFactoryMock;

        public FactoryFixture(INullableStringArgumentPatternFactory sut, Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
        }

        INullableStringArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableStringArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;
    }
}
