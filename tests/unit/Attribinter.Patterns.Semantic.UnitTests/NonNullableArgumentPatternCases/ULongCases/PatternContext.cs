namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ULongCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IULongArgumentPatternFactory)new ULongArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, ulong> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, ulong> pattern)
    {
        Pattern = pattern;
    }
}
