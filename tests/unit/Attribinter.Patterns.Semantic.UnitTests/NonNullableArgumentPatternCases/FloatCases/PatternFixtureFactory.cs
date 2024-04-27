namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.FloatCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IFloatArgumentPatternFactory)new FloatArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, float> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, float> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, float> IPatternFixture.Sut => Sut;
    }
}
