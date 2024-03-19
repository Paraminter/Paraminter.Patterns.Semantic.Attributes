namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.UIntCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IUIntArgumentPatternFactory)new UIntArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, uint> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, uint> pattern)
    {
        Pattern = pattern;
    }
}
