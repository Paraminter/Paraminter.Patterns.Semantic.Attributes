namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.BoolCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IBoolArgumentPatternFactory)new BoolArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, bool> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, bool> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, bool> IPatternFixture.Sut => Sut;
    }
}
