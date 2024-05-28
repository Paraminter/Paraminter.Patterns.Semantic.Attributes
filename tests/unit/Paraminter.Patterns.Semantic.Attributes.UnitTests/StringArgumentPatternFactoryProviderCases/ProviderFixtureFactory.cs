namespace Paraminter.Patterns.Semantic.Attributes.StringArgumentPatternFactoryProviderCases;

using Moq;

internal static class ProviderFixtureFactory
{
    public static IProviderFixture Create()
    {
        Mock<INonNullableStringArgumentPatternFactory> nonNullableMock = new();
        Mock<INullableStringArgumentPatternFactory> nullableMock = new();

        StringArgumentPatternFactoryProvider sut = new(nonNullableMock.Object, nullableMock.Object);

        return new ProviderFixture(sut, nonNullableMock, nullableMock);
    }

    private sealed class ProviderFixture
        : IProviderFixture
    {
        private readonly IStringArgumentPatternFactoryProvider Sut;

        private readonly Mock<INonNullableStringArgumentPatternFactory> NonNullableMock;
        private readonly Mock<INullableStringArgumentPatternFactory> NullableMock;

        public ProviderFixture(
            IStringArgumentPatternFactoryProvider sut,
            Mock<INonNullableStringArgumentPatternFactory> nonNullableMock,
            Mock<INullableStringArgumentPatternFactory> nullableMock)
        {
            Sut = sut;

            NonNullableMock = nonNullableMock;
            NullableMock = nullableMock;
        }

        IStringArgumentPatternFactoryProvider IProviderFixture.Sut => Sut;

        Mock<INonNullableStringArgumentPatternFactory> IProviderFixture.NonNullableMock => NonNullableMock;
        Mock<INullableStringArgumentPatternFactory> IProviderFixture.NullableMock => NullableMock;
    }
}
