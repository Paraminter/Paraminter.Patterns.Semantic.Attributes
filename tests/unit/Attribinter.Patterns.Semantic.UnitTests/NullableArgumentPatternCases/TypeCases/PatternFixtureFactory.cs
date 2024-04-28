namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.TypeCases;

using Microsoft.CodeAnalysis;

using Moq;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> nonNullablePatternMock = new();

        Mock<INonNullableTypeArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePatternMock.Object);

        var sut = ((INullableTypeArgumentPatternFactory)new NullableTypeArgumentPatternFactory(nonNullablePatternFactoryMock.Object)).Create();

        return new PatternFixture(sut, nonNullablePatternMock);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, ITypeSymbol?> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> NonNullablePatternMock;

        public PatternFixture(IArgumentPattern<TypedConstant, ITypeSymbol?> sut, Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> nonNullablePatternMock)
        {
            Sut = sut;

            NonNullablePatternMock = nonNullablePatternMock;
        }

        IArgumentPattern<TypedConstant, ITypeSymbol?> IPatternFixture.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, ITypeSymbol>> IPatternFixture.NonNullablePatternMock => NonNullablePatternMock;
    }
}
