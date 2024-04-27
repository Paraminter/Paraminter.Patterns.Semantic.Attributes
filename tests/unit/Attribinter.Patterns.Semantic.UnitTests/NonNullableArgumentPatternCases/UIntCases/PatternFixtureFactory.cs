namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.UIntCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IUIntArgumentPatternFactory)new UIntArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, uint> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, uint> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, uint> IPatternFixture.Sut => Sut;
    }
}
