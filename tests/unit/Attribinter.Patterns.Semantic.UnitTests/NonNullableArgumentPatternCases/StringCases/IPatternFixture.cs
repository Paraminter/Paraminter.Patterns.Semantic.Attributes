namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, string> Sut { get; }
}
