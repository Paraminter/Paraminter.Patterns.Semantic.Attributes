namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.SByteCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, sbyte> Sut { get; }
}
