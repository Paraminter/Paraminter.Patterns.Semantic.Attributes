namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, ITypeSymbol?> Sut { get; }

    public abstract Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> NonNullablePatternMock { get; }
}
