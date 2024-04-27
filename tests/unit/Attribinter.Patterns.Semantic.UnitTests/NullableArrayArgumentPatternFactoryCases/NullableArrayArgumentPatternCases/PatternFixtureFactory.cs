namespace Attribinter.Patterns.Semantic.NullableArrayArgumentPatternFactoryCases.NullableArrayArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System.Collections.Generic;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<TElement> Create<TElement>()
    {
        Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> nonNullablePatternMock = new() { DefaultValue = DefaultValue.Mock };

        Mock<INonNullableArrayArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create(It.IsAny<IArgumentPattern<TypedConstant, TElement>>())).Returns(nonNullablePatternMock.Object);

        INullableArrayArgumentPatternFactory nullablePatternFactory = new NullableArrayArgumentPatternFactory(nonNullablePatternFactoryMock.Object);

        var sut = nullablePatternFactory.Create(Mock.Of<IArgumentPattern<TypedConstant, TElement>>());

        return new PatternFixture<TElement>(sut, nonNullablePatternMock);
    }

    private sealed class PatternFixture<TElement> : IPatternFixture<TElement>
    {
        private readonly IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> NonNullablePatternMock;

        public PatternFixture(IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> sut, Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> nonNullablePatternMock)
        {
            Sut = sut;

            NonNullablePatternMock = nonNullablePatternMock;
        }

        IArgumentPattern<TypedConstant, IReadOnlyList<TElement>?> IPatternFixture<TElement>.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, IReadOnlyList<TElement>>> IPatternFixture<TElement>.NonNullablePatternMock => NonNullablePatternMock;
    }
}
