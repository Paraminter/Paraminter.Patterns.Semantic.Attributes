namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IPatternFixture<TEnum>
{
    public abstract IArgumentPattern<TypedConstant, TEnum> Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
