namespace Paraminter.Patterns.Semantic.Attributes.ShortArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IShortArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
