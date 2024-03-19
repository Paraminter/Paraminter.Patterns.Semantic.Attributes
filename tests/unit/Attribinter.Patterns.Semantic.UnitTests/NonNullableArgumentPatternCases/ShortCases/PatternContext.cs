namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ShortCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IShortArgumentPatternFactory)new ShortArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, short> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, short> pattern)
    {
        Pattern = pattern;
    }
}
