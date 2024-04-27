namespace Attribinter.Patterns.Semantic.NonNullableObjectArgumentPatternFactoryCases.NonNullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((INonNullableObjectArgumentPatternFactory)new NonNullableObjectArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, object> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, object> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, object> IPatternFixture.Sut => Sut;
    }
}
