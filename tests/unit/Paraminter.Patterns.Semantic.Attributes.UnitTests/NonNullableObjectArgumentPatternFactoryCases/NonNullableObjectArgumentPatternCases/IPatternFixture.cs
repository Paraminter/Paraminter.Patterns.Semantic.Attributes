namespace Paraminter.Patterns.Semantic.Attributes.NonNullableObjectArgumentPatternFactoryCases.NonNullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal interface IPatternFixture
{
    public abstract IArgumentPattern<TypedConstant, object> Sut { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
