namespace Paraminter.Patterns.Semantic.Attributes.NullableArrayArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableArrayArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableArrayArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
