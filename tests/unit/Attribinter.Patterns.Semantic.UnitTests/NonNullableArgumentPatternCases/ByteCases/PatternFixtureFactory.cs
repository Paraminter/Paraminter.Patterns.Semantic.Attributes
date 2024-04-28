namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ByteCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        var sut = ((IByteArgumentPatternFactory)new ByteArgumentPatternFactory()).Create();

        return new PatternFixture(sut);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, byte> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, byte> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, byte> IPatternFixture.Sut => Sut;
    }
}
