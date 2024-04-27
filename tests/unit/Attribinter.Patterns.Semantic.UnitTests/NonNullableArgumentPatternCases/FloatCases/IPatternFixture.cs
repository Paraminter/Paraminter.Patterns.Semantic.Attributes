namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.FloatCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, float> Sut { get; }
}
