namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases;

using Moq;

internal interface IFactoryFixture
{
    public abstract INullableArrayArgumentPatternFactory Sut { get; }

    public abstract Mock<INonNullableArrayArgumentPatternFactory> NonNullablePatternFactoryMock { get; }
}
