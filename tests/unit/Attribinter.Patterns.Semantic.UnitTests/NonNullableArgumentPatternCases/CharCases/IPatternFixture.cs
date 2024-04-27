namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.CharCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, char> Sut { get; }
}
