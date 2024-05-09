namespace Paraminter.Patterns.Semantic.Attributes.LongArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract ILongArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
