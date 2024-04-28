namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using System;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<TEnum> Create<TEnum>()
        where TEnum : Enum
    {
        var sut = ((IEnumArgumentPatternFactory)new EnumArgumentPatternFactory()).Create<TEnum>();

        return new PatternFixture<TEnum>(sut);
    }

    private sealed class PatternFixture<TEnum> : IPatternFixture<TEnum>
    {
        private readonly IArgumentPattern<TypedConstant, TEnum> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, TEnum> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, TEnum> IPatternFixture<TEnum>.Sut => Sut;
    }
}
