namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.BoolCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, bool> Sut { get; }
}
