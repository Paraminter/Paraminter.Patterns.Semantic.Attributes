namespace Attribinter.Patterns.Semantic.ArrayArgumentPatternFactoryProviderCases;

using Moq;

internal interface IProviderFixture
{
    public abstract IArrayArgumentPatternFactoryProvider Sut { get; }

    public abstract Mock<INonNullableArrayArgumentPatternFactory> NonNullableMock { get; }
    public abstract Mock<INullableArrayArgumentPatternFactory> NullableMock { get; }
}
