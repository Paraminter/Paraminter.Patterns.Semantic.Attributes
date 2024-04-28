namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases.NullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal interface IPatternFixture<TElement>
{
    public abstract IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> Sut { get; }

    public abstract Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> NonNullablePatternMock { get; }
}
