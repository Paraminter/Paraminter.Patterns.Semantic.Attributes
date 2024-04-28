namespace Attribinter.Patterns.Semantic.NullableObjectArgumentPatternFactoryCases.NullableObjectArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        Mock<IArgumentPattern<TypedConstant, object>> nonNullablePatternMock = new();

        Mock<INonNullableObjectArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePatternMock.Object);

        var sut = ((INullableObjectArgumentPatternFactory)new NullableObjectArgumentPatternFactory(nonNullablePatternFactoryMock.Object)).Create();

        return new PatternFixture(sut, nonNullablePatternMock);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, object?> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, object>> NonNullablePatternMock;

        public PatternFixture(IArgumentPattern<TypedConstant, object?> sut, Mock<IArgumentPattern<TypedConstant, object>> nonNullablePatternMock)
        {
            Sut = sut;

            NonNullablePatternMock = nonNullablePatternMock;
        }

        IArgumentPattern<TypedConstant, object?> IPatternFixture.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, object>> IPatternFixture.NonNullablePatternMock => NonNullablePatternMock;
    }
}
