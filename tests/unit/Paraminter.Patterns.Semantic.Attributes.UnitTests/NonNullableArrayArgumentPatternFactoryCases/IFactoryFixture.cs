namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArrayArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INonNullableArrayArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
