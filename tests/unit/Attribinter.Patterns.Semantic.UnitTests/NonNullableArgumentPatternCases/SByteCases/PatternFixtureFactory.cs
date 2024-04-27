namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.SByteCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((ISByteArgumentPatternFactory)new SByteArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, sbyte> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, sbyte> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, sbyte> IPatternFixture.Sut => Sut;
    }
}
