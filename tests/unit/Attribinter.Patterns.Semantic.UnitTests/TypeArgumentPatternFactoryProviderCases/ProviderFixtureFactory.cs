namespace Attribinter.Patterns.Semantic.TypeArgumentPatternFactoryProviderCases;

using Moq;

internal static class ProviderFixtureFactory
{
    public static IProviderFixture Create()
    {
        Mock<INonNullableTypeArgumentPatternFactory> nonNullableMock = new();
        Mock<INullableTypeArgumentPatternFactory> nullableMock = new();

        TypeArgumentPatternFactoryProvider sut = new(nonNullableMock.Object, nullableMock.Object);

        return new ProviderFixture(sut, nonNullableMock, nullableMock);
    }

    private sealed class ProviderFixture : IProviderFixture
    {
        private readonly ITypeArgumentPatternFactoryProvider Sut;

        private readonly Mock<INonNullableTypeArgumentPatternFactory> NonNullableMock;
        private readonly Mock<INullableTypeArgumentPatternFactory> NullableMock;

        public ProviderFixture(ITypeArgumentPatternFactoryProvider sut, Mock<INonNullableTypeArgumentPatternFactory> nonNullableMock, Mock<INullableTypeArgumentPatternFactory> nullableMock)
        {
            Sut = sut;

            NonNullableMock = nonNullableMock;
            NullableMock = nullableMock;
        }

        ITypeArgumentPatternFactoryProvider IProviderFixture.Sut => Sut;

        Mock<INonNullableTypeArgumentPatternFactory> IProviderFixture.NonNullableMock => NonNullableMock;
        Mock<INullableTypeArgumentPatternFactory> IProviderFixture.NullableMock => NullableMock;
    }
}
