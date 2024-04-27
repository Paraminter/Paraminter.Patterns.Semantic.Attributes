namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ShortCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IShortArgumentPatternFactory)new ShortArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, short> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, short> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, short> IPatternFixture.Sut => Sut;
    }
}
