namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ULongCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IULongArgumentPatternFactory)new ULongArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, ulong> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, ulong> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, ulong> IPatternFixture.Sut => Sut;
    }
}
