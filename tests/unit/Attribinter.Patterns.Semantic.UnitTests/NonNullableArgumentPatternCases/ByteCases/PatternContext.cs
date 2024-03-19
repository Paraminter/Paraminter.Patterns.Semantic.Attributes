namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ByteCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IByteArgumentPatternFactory)new ByteArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, byte> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, byte> pattern)
    {
        Pattern = pattern;
    }
}
