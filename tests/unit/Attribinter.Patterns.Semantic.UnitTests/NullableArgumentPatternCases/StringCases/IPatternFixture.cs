namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, string?> Sut { get; }

    public abstract Mock<IArgumentPattern<TypedConstant, string>> NonNullablePatternMock { get; }
}
