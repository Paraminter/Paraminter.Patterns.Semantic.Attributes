namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_ULongEnum
{
    [Fact]
    public void ULongEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [ULongEnumAttribute(ULongEnum.None)]
            public class Foo { }
            """;

        Successful(ULongEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ULongEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(ULongEnum.None)]
            public class Foo { }
            """;

        Successful(ULongEnum.None, source);
    }

    private IArgumentPatternMatchResult<ULongEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<ULongEnum> Fixture = PatternFixtureFactory.Create<ULongEnum>();

    [AssertionMethod]
    private void Successful(ULongEnum matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ULongEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
