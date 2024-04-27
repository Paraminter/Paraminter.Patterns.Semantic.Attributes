namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.UShortCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IUShortArgumentPatternFactory)new UShortArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, ushort> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, ushort> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, ushort> IPatternFixture.Sut => Sut;
    }
}
