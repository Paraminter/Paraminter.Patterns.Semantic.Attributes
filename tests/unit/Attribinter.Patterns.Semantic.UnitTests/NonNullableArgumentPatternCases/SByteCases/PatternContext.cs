namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.SByteCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((ISByteArgumentPatternFactory)new SByteArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, sbyte> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, sbyte> pattern)
    {
        Pattern = pattern;
    }
}
