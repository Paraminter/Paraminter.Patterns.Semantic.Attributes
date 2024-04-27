namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<TOut> Create<TOut>(IArgumentPattern<TypedConstant, TOut> sut) => new PatternFixture<TOut>(sut);

    private sealed class PatternFixture<TOut> : IPatternFixture<TOut>
    {
        private readonly IArgumentPattern<TypedConstant, TOut> Sut;

        public PatternFixture(IArgumentPattern<TypedConstant, TOut> sut)
        {
            Sut = sut;
        }

        IArgumentPattern<TypedConstant, TOut> IPatternFixture<TOut>.Sut => Sut;
    }
}
