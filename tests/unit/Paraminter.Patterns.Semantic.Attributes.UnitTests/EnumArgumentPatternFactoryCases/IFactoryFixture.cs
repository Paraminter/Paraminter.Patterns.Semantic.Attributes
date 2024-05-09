namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IEnumArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
