namespace Attribinter.Patterns.Semantic.NonNullableObjectArgumentPatternFactoryCases.NonNullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((INonNullableObjectArgumentPatternFactory)new NonNullableObjectArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, object> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, object> pattern)
    {
        Pattern = pattern;
    }
}
