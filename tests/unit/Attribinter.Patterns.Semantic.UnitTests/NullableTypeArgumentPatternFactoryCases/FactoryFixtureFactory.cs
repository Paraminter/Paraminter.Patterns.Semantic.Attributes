namespace Attribinter.Patterns.Semantic.NullableTypeArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableTypeArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INullableTypeArgumentPatternFactory Sut;

        private readonly Mock<INonNullableTypeArgumentPatternFactory> NonNullablePatternFactoryMock;

        public FactoryFixture(INullableTypeArgumentPatternFactory sut, Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
        }

        INullableTypeArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableTypeArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;
    }
}
