namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.FloatCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IFloatArgumentPatternFactory)new FloatArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, float> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, float> pattern)
    {
        Pattern = pattern;
    }
}
