namespace Attribinter.Patterns.Semantic.NullableStringArgumentPatternFactoryCases;

using Moq;

internal sealed class FactoryContext
{
    public static FactoryContext Create()
    {
        Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock = new() { DefaultValue = DefaultValue.Mock };

        NullableStringArgumentPatternFactory factory = new(nonNullablePatternFactoryMock.Object);

        return new(factory, nonNullablePatternFactoryMock);
    }

    public NullableStringArgumentPatternFactory Factory { get; }

    public Mock<INonNullableStringArgumentPatternFactory> NonNullablePatternFactoryMock { get; }

    private FactoryContext(NullableStringArgumentPatternFactory factory, Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock)
    {
        Factory = factory;

        NonNullablePatternFactoryMock = nonNullablePatternFactoryMock;
    }
}
