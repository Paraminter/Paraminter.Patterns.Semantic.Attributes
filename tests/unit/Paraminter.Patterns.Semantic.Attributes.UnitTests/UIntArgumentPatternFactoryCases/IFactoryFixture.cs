namespace Paraminter.Patterns.Semantic.Attributes.UIntArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IUIntArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
