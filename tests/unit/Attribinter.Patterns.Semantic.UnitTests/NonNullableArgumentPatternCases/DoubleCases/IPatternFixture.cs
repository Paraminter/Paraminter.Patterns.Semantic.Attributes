namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.DoubleCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, double> Sut { get; }
}
