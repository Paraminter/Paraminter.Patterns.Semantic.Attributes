namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using System;

internal sealed class PatternContext<TEnum> where TEnum : Enum
{
    public static PatternContext<TEnum> Create()
    {
        var pattern = ((IEnumArgumentPatternFactory)new EnumArgumentPatternFactory()).Create<TEnum>();

        return new(pattern);
    }

    public IArgumentPattern<TypedConstant, TEnum> Pattern { get; }

    private PatternContext(IArgumentPattern<TypedConstant, TEnum> pattern)
    {
        Pattern = pattern;
    }
}
