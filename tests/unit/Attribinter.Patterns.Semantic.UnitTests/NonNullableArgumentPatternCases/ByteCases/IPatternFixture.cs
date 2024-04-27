namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ByteCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, byte> Sut { get; }
}
