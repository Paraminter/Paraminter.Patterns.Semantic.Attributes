namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.UShortCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, ushort> Sut { get; }
}
