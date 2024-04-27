namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.IntCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IIntArgumentPatternFactory)new IntArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, int> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, int> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, int> IPatternFixture.Sut => Sut;
    }
}
