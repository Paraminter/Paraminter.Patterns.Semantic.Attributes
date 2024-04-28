namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.DoubleCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IDoubleArgumentPatternFactory)new DoubleArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, double> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, double> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, double> IPatternFixture.Sut => Sut;
    }
}
