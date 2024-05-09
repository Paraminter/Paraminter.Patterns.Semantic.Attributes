namespace Paraminter.Patterns.Semantic.Attributes.NullableStringArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableStringArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableStringArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
