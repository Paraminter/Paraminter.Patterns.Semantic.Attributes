namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, ITypeSymbol> Sut { get; }
}
