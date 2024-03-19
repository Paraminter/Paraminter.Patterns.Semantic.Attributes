namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.CharCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((ICharArgumentPatternFactory)new CharArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, char> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, char> pattern)
    {
        Pattern = pattern;
    }
}
