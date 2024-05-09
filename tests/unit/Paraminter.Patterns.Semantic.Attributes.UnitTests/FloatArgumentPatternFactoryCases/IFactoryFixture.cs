namespace Paraminter.Patterns.Semantic.Attributes.FloatArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IFloatArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
