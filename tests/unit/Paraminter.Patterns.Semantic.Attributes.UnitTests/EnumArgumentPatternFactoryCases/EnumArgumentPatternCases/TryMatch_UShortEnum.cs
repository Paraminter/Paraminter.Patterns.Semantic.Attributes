namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_UShortEnum
{
    private readonly IPatternFixture<UShortEnum> Fixture = PatternFixtureFactory.Create<UShortEnum>();

    [Fact]
    public void UShortEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [UShortEnumAttribute(UShortEnum.None)]
            public class Foo { }
            """;

        Successful(UShortEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_UShortEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(UShortEnum.None)]
            public class Foo { }
            """;

        Successful(UShortEnum.None, source);
    }

    private IArgumentPatternMatchResult<UShortEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(UShortEnum matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<UShortEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
