namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.UIntCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, uint> Sut { get; }
}
