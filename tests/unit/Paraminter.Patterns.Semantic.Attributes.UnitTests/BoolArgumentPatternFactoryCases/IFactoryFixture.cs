namespace Paraminter.Patterns.Semantic.Attributes.BoolArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IBoolArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
