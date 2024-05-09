namespace Paraminter.Patterns.Semantic.Attributes.ArrayArgumentPatternFactoryProviderCases;

using Moq;

internal static class ProviderFixtureFactory
{
    public static IProviderFixture Create()
    {
        Mock<INonNullableArrayArgumentPatternFactory> nonNullableMock = new();
        Mock<INullableArrayArgumentPatternFactory> nullableMock = new();

        ArrayArgumentPatternFactoryProvider sut = new(nonNullableMock.Object, nullableMock.Object);

        return new ProviderFixture(sut, nonNullableMock, nullableMock);
    }

    private sealed class ProviderFixture : IProviderFixture
    {
        private readonly IArrayArgumentPatternFactoryProvider Sut;

        private readonly Mock<INonNullableArrayArgumentPatternFactory> NonNullableMock;
        private readonly Mock<INullableArrayArgumentPatternFactory> NullableMock;

        public ProviderFixture(IArrayArgumentPatternFactoryProvider sut, Mock<INonNullableArrayArgumentPatternFactory> nonNullableMock, Mock<INullableArrayArgumentPatternFactory> nullableMock)
        {
            Sut = sut;

            NonNullableMock = nonNullableMock;
            NullableMock = nullableMock;
        }

        IArrayArgumentPatternFactoryProvider IProviderFixture.Sut => Sut;

        Mock<INonNullableArrayArgumentPatternFactory> IProviderFixture.NonNullableMock => NonNullableMock;
        Mock<INullableArrayArgumentPatternFactory> IProviderFixture.NullableMock => NullableMock;
    }
}
