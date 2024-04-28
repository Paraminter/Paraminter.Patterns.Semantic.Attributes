namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases.NullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, object?> Sut { get; }

    public abstract Mock<IArgumentPattern<TypedConstant, object>> NonNullablePatternMock { get; }
}
