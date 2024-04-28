namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.IntCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, int> Sut { get; }
}
