namespace Paraminter.Patterns.Semantic.Attributes.CharArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract ICharArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
