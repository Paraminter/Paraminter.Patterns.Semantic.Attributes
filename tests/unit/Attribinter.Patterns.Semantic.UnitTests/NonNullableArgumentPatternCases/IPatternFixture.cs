namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture<TOut>
{
    public abstract IArgumentPattern<TypedConstant, TOut> Sut { get; }
}
