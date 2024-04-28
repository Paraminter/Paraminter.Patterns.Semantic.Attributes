namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.LongCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, long> Sut { get; }
}
