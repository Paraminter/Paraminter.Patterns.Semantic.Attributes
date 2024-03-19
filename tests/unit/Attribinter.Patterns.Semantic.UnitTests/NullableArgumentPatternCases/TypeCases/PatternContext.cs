namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using Moq;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> nonNullablePatternMock = new();

        Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePatternMock.Object);

        var pattern = ((INullableTypeArgumentPatternFactory)new NullableTypeArgumentPatternFactory(nonNullablePatternFactoryMock.Object)).Create();

        return new(pattern, nonNullablePatternMock);
    }

    public IArgumentPattern<TypedConstant, ITypeSymbol?> Pattern { get; }

    public Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> NonNullablePatternMock { get; }

    private PatternContext(IArgumentPattern<TypedConstant, ITypeSymbol?> pattern, Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> nonNullablePatternMock)
    {
        Pattern = pattern;

        NonNullablePatternMock = nonNullablePatternMock;
    }
}
