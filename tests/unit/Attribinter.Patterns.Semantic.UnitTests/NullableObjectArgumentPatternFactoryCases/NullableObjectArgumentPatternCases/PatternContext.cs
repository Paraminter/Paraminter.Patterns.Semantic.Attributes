namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases.NullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        Mock<IArgumentPattern<TypedConstant, object>> nonNullablePatternMock = new();

        Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePatternMock.Object);

        var pattern = ((INullableObjectArgumentPatternFactory)new NullableObjectArgumentPatternFactory(nonNullablePatternFactoryMock.Object)).Create();

        return new(pattern, nonNullablePatternMock);
    }

    public IArgumentPattern<TypedConstant, object?> Pattern { get; }

    public Mock<IArgumentPattern<TypedConstant, object>> NonNullablePatternMock { get; }

    private PatternContext(IArgumentPattern<TypedConstant, object?> pattern, Mock<IArgumentPattern<TypedConstant, object>> nonNullablePatternMock)
    {
        Pattern = pattern;

        NonNullablePatternMock = nonNullablePatternMock;
    }
}
