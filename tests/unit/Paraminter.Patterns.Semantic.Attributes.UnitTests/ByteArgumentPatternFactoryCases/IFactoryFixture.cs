namespace Paraminter.Patterns.Semantic.Attributes.ByteArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract IByteArgumentPatternFactory Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
