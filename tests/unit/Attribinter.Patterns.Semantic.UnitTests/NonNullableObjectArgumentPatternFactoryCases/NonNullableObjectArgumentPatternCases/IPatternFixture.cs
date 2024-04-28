namespace Attribinter.Patterns.Semantic.NonNullableObjectArgumentPatternFactoryCases.NonNullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, object> Sut { get; }
}
