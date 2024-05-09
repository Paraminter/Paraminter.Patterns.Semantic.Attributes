namespace Paraminter.Patterns.Semantic.Attributes.DoubleArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IDoubleArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
