namespace Attribinter.Patterns.Semantic.NullableArgumentPatternCases.StringCases;

using Microsoft.CodeAnalysis;

using Moq;

internal static class PatternFixtureFactory
{
    public static IPatternFixture Create()
    {
        Mock<IArgumentPattern<TypedConstant, string>> nonNullablePatternMock = new();

        Mock<INonNullableStringArgumentPatternFactory> nonNullablePatternFactoryMock = new();

        nonNullablePatternFactoryMock.Setup(static (factory) => factory.Create()).Returns(nonNullablePatternMock.Object);

        var sut = ((INullableStringArgumentPatternFactory)new NullableStringArgumentPatternFactory(nonNullablePatternFactoryMock.Object)).Create();

        return new PatternFixture(sut, nonNullablePatternMock);
    }

    private sealed class PatternFixture : IPatternFixture
    {
        private readonly IArgumentPattern<TypedConstant, string?> Sut;

        private readonly Mock<IArgumentPattern<TypedConstant, string>> NonNullablePatternMock;

        public PatternFixture(IArgumentPattern<TypedConstant, string?> sut, Mock<IArgumentPattern<TypedConstant, string>> nonNullablePatternMock)
        {
            Sut = sut;

            NonNullablePatternMock = nonNullablePatternMock;
        }

        IArgumentPattern<TypedConstant, string?> IPatternFixture.Sut => Sut;

        Mock<IArgumentPattern<TypedConstant, string>> IPatternFixture.NonNullablePatternMock => NonNullablePatternMock;
    }
}
