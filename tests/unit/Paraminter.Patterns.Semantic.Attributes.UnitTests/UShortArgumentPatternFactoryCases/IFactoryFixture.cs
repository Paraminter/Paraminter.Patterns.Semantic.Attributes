namespace Paraminter.Patterns.Semantic.Attributes.UShortArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IUShortArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
