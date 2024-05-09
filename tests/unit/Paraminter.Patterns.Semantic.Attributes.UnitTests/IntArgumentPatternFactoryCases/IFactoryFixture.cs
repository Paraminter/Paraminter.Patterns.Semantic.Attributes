namespace Paraminter.Patterns.Semantic.Attributes.IntArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IIntArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
