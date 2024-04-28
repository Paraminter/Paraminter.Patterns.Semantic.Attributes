namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableObjectArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INullableObjectArgumentPatternFactory Sut;

        private readonly Mock<INonNullableObjectArgumentPatternFactory> NonNullablePatternFactoryMock;

        public FactoryFixture(INullableObjectArgumentPatternFactory sut, Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
        }

        INullableObjectArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableObjectArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;
    }
}
