namespace Attribinter.Patterns.Semantic.NullableStringArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableStringArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableStringArgumentPatternFactory> NonNullablePatternFactoryMock { get; }
}
