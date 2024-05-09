namespace Paraminter.Patterns.Semantic.Attributes.NonNullableArrayArgumentPatternFactoryCases.NonNullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal interface IPatternFixture<TElement>
{
    public abstract IArgumentPattern<TypedConstant, IReadOnlyList<TElement>> Sut { get; }

    public abstract Mock<IArgumentPattern<TypedConstant, TElement>> ElementPatternMock { get; }

    public abstract Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock { get; }
}
