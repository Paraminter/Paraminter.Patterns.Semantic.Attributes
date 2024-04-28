namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableObjectArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableObjectArgumentPatternFactory> NonNullablePatternFactoryMock { get; }
}
