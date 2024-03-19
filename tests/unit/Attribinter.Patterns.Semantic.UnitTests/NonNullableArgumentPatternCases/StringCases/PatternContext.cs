namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((INonNullableStringArgumentPatternFactory)new NonNullableStringArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, string> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, string> pattern)
    {
        Pattern = pattern;
    }
}
