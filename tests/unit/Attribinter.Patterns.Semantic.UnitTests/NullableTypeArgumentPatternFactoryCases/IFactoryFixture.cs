namespace Attribinter.Patterns.Semantic.NullableTypeArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableTypeArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableTypeArgumentPatternFactory> NonNullablePatternFactoryMock { get; }
}
