namespace Paraminter.Patterns.Semantic.Attributes.ObjectArgumentPatternFactoryProviderCases;

using Moq;

internal static class ProviderFixtureFactory
{
    public static IProviderFixture Create()
    {
        Mock<INonNullableObjectArgumentPatternFactory> nonNullableMock = new();
        Mock<INullableObjectArgumentPatternFactory> nullableMock = new();

        ObjectArgumentPatternFactoryProvider sut = new(nonNullableMock.Object, nullableMock.Object);

        return new ProviderFixture(sut, nonNullableMock, nullableMock);
    }

    private sealed class ProviderFixture
        : IProviderFixture
    {
        private readonly IObjectArgumentPatternFactoryProvider Sut;

        private readonly Mock<INonNullableObjectArgumentPatternFactory> NonNullableMock;
        private readonly Mock<INullableObjectArgumentPatternFactory> NullableMock;

        public ProviderFixture(
            IObjectArgumentPatternFactoryProvider sut,
            Mock<INonNullableObjectArgumentPatternFactory> nonNullableMock,
            Mock<INullableObjectArgumentPatternFactory> nullableMock)
        {
            Sut = sut;

            NonNullableMock = nonNullableMock;
            NullableMock = nullableMock;
        }

        IObjectArgumentPatternFactoryProvider IProviderFixture.Sut => Sut;

        Mock<INonNullableObjectArgumentPatternFactory> IProviderFixture.NonNullableMock => NonNullableMock;
        Mock<INullableObjectArgumentPatternFactory> IProviderFixture.NullableMock => NullableMock;
    }
}
