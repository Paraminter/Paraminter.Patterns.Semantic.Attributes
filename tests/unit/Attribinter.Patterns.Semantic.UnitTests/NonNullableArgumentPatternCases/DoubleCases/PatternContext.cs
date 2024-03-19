namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.DoubleCases;

using Microsoft.CodeAnalysis;

internal sealed class PatternContext
{
    public static PatternContext Create()
    {
        var pattern = ((IDoubleArgumentPatternFactory)new DoubleArgumentPatternFactory()).Create();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, double> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, double> pattern)
    {
        Pattern = pattern;
    }
}
