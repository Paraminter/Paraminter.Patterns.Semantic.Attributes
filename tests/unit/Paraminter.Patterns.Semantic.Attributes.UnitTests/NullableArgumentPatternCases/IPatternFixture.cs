namespace Paraminter.Patterns.Semantic.Attributes.NullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IPatternFixture<TOut>
{
    public abstract IArgumentPattern<TypedConstant, TOut?> Sut { get; }

    public abstract Mock<IArgumentPattern<TypedConstant, TOut>> NonNullablePatternMock { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
