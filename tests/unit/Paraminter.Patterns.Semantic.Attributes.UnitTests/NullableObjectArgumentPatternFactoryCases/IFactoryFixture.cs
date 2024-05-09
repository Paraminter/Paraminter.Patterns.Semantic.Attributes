namespace Paraminter.Patterns.Semantic.Attributes.NullableObjectArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableObjectArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableObjectArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
