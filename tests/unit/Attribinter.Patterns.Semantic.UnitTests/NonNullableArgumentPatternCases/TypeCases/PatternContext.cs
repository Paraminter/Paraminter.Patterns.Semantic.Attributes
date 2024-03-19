namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((INonNullableTypeArgumentPatternFactory)new NonNullableTypeArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, ITypeSymbol> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, ITypeSymbol> pattern)
    {
        Pattern = pattern;
    }
}
