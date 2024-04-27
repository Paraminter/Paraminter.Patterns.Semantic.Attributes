namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases;

using Moq;

internal static class FactoryFixtureFactory
{
    public static IFactoryFixture Create()
    {
        Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableArrayArgumentPatternFactory sut = new(nonNullablePatternFactoryMock.Object);

        return new FactoryFixture(sut, nonNullablePatternFactoryMock);
    }

    private sealed class FactoryFixture : IFactoryFixture
    {
        private readonly INullableArrayArgumentPatternFactory Sut;

        private readonly Mock<INonNullableArrayArgumentPatternFactory> NonNullablePatternFactoryMock;

        public FactoryFixture(INullableArrayArgumentPatternFactory sut, Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock)
        {
            Sut = sut;

            NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
        }

        INullableArrayArgumentPatternFactory IFactoryFixture.Sut => Sut;

        Mock<INonNullableArrayArgumentPatternFactory> IFactoryFixture.NonNullablePatternFactoryMock => NonNullablePatternFactoryMock;
    }
}
