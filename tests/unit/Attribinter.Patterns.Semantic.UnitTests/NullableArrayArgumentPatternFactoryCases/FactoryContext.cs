namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases;

using Moq;

internal sealed class FactoryContext
{
    public static FactoryContext Create()
    {
        Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableArrayArgumentPatternFactory factory = new(nonNullablePatternFactoryMock.Object);

        return new(factory, nonNullablePatternFactoryMock);
    }

    public INullableArrayArgumentPatternFactory Factory { get; }

    public Mock<INonNullableArrayArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    public FactoryContext(INullableArrayArgumentPatternFactory factory, Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock)
    {
        Factory = factory;

        NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
    }
}
