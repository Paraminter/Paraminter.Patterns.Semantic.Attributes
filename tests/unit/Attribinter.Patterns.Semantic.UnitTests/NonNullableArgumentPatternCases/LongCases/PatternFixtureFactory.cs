namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.LongCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((ILongArgumentPatternFactory)new LongArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, long> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, long> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, long> IPatternFixture.Sut => Sut;
    }
}
