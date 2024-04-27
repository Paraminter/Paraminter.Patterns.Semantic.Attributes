namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((INonNullableStringArgumentPatternFactory)new NonNullableStringArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, string> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, string> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, string> IPatternFixture.Sut => Sut;
    }
}
