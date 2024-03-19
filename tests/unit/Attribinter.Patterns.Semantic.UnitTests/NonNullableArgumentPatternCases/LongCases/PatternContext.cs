namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.LongCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((ILongArgumentPatternFactory)new LongArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, long> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, long> pattern)
    {
        Pattern = pattern;
    }
}
