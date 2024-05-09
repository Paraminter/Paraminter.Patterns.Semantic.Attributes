namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IPatternFixture<TOut>
{
    public abstract IArgumentPattern<TypedConstant, TOut> Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
