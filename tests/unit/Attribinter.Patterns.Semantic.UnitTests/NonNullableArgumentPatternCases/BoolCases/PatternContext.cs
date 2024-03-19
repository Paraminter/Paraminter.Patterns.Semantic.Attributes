namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.BoolCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IBoolArgumentPatternFactory)new BoolArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, bool> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, bool> pattern)
    {
        Pattern = pattern;
    }
}
