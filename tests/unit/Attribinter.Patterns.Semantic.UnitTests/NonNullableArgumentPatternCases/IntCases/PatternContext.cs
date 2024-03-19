namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.IntCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IIntArgumentPatternFactory)new IntArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, int> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, int> pattern)
    {
        Pattern = pattern;
    }
}
