namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ShortCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, short> Sut { get; }
}
