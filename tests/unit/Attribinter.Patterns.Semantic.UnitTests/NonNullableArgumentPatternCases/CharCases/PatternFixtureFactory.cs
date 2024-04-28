namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.CharCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((ICharArgumentPatternFactory)new CharArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, char> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, char> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, char> IPatternFixture.Sut => Sut;
    }
}
