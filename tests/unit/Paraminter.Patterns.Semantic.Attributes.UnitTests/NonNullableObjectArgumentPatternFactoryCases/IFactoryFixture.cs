namespace Paraminter.Patterns.Semantic.Attributes.NonNullableObjectArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INonNullableObjectArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
