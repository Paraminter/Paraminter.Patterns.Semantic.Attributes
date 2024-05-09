namespace Paraminter.Patterns.Semantic.Attributes.NullableTypeArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableTypeArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableTypeArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
