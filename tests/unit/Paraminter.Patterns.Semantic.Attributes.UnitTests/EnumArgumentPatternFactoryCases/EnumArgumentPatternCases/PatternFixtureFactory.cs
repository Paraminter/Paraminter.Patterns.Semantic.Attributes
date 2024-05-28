namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using System;

internal static class PatternFixtureFactory
{
    public static IPatternFixture<TEnum> Create<TEnum>()
        where TEnum : Enum
    {
        Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock = new();

        IEnumArgumentPatternFactory factory = new EnumArgumentPatternFactory(matchResultFactoryProviderMock.Object);

        var sut = factory.Create<TEnum>();

        return new PatternFixture<TEnum>(sut, matchResultFactoryProviderMock);
    }

    private sealed class PatternFixture<TEnum>
        : IPatternFixture<TEnum>
    {
        private readonly IArgumentPattern<TypedConstant, TEnum> Sut;

        private readonly Mock<IArgumentPatternMatchResultFactoryProvider> MatchResultFactoryProviderMock;

        public PatternFixture(
            IArgumentPattern<TypedConstant, TEnum> sut,
            Mock<IArgumentPatternMatchResultFactoryProvider> matchResultFactoryProviderMock)
        {
            Sut = sut;

            MatchResultFactoryProviderMock = matchResultFactoryProviderMock;
        }

        IArgumentPattern<TypedConstant, TEnum> IPatternFixture<TEnum>.Sut => Sut;

        Mock<IArgumentPatternMatchResultFactoryProvider> IPatternFixture<TEnum>.MatchResultFactoryProviderMock => MatchResultFactoryProviderMock;
    }
}
