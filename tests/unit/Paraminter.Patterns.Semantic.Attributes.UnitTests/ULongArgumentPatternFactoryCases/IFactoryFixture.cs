namespace Paraminter.Patterns.Semantic.Attributes.ULongArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IULongArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
