namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.UShortCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IUShortArgumentPatternFactory)new UShortArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, ushort> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, ushort> pattern)
    {
        Pattern = pattern;
    }
}
