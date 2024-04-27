namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ULongCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, ulong> Sut { get; }
}
