namespace Paraminter.Patterns.Semantic.Attributes.NonNullableTypeArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INonNullableTypeArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
