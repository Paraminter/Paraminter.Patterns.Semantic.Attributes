namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((INonNullableTypeArgumentPatternFactory)new NonNullableTypeArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, ITypeSymbol> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, ITypeSymbol> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, ITypeSymbol> IPatternFixture.Sut => Sut;
    }
}
