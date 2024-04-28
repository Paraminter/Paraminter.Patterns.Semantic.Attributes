namespace Attribinter.Patterns.Semantic.ObjectArgumentPatternFactoryProviderCases;

using Moq;

internal interface IProviderFixture
{
    public abstract IObjectArgumentPatternFactoryProvider Sut { get; }

    public abstract Mock<INonNullableObjectArgumentPatternFactory> NonNullableMock { get; }
    public abstract Mock<INullableObjectArgumentPatternFactory> NullableMock { get; }
}
