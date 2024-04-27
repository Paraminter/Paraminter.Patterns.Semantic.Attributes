namespace Attribinter.Patterns.Semantic.StringArgumentPatternFactoryProviderCases;

using Moq;

internal interface IProviderFixture
{
    public abstract IStringArgumentPatternFactoryProvider Sut { get; }

    public abstract Mock<INonNullableStringArgumentPatternFactory> NonNullableMock { get; }
    public abstract Mock<INullableStringArgumentPatternFactory> NullableMock { get; }
}
