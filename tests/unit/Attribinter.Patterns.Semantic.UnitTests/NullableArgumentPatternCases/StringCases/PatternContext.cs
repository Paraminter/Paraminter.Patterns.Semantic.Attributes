namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

using Moq;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        Mock<IArgumentPattern<TypedConstant, string>> nonNullablePatternMock = new();

        Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePatternMock.Object);

        var pattern = ((INullableStringArgumentPatternFactory)new NullableStringArgumentPatternFactory(nonNullablePatternFactoryMock.Object)).Create();

        return new(pattern, nonNullablePatternMock);
    }

    public IArgumentPattern<TypedConstant, string?> Pattern { get; }

    public Mock<IArgumentPattern<TypedConstant, string>> NonNullablePatternMock { get; }

    private PatternContext(IArgumentPattern<TypedConstant, string?> pattern, Mock<IArgumentPattern<TypedConstant, string>> nonNullablePatternMock)
    {
        Pattern = pattern;

        NonNullablePatternMock = nonNullablePatternMock;
    }
}
