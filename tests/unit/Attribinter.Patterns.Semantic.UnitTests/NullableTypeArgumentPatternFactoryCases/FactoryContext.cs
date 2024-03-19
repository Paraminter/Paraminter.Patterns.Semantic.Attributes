namespace Attribinter.Patterns.Semantic.NullableTypeArgumentPatternFactoryCases;

using Moq;

internal sealed class FactoryContext
{
    public static FactoryContext Create()
    {
        Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableTypeArgumentPatternFactory factory = new(nonNullablePatternFactoryMock.Object);

        return new(factory, nonNullablePatternFactoryMock);
    }

    public NullableTypeArgumentPatternFactory Factory { get; }

    public Mock<INonNullableTypeArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    private FactoryContext(NullableTypeArgumentPatternFactory factory, Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock)
    {
        Factory = factory;

        NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
    }
}
