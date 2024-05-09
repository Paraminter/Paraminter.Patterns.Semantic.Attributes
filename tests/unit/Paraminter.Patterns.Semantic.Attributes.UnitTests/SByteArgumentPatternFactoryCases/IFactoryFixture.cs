namespace Paraminter.Patterns.Semantic.Attributes.SByteArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract ISByteArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
