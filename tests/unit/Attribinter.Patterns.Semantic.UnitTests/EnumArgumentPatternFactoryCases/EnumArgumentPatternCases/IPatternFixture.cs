namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

internal interface IPatternFixture<TEnum>
{
    public abstract IArgumentPattern<TypedConstant, TEnum> Sut { get; }
}
