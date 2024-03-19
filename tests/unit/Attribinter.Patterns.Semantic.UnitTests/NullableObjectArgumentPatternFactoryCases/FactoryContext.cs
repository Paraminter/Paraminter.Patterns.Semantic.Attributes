namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases;

using Moq;

internal sealed class FactoryContext
{
    public static FactoryContext Create()
    {
        Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableObjectArgumentPatternFactory factory = new(nonNullablePatternFactoryMock.Object);

        return new(factory, nonNullablePatternFactoryMock);
    }

    public NullableObjectArgumentPatternFactory Factory { get; }

    public Mock<INonNullableObjectArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    private FactoryContext(NullableObjectArgumentPatternFactory factory, Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock)
    {
        Factory = factory;

        NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
    }
}
