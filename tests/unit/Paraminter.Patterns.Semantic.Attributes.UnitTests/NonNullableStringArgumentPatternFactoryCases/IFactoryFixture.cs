namespace Paraminter.Patterns.Semantic.Attributes.NonNullableStringArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INonNullableStringArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
