namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_LongEnum
{
    private readonly IPatternFixture<LongEnum> Fixture = PatternFixtureFactory.Create<LongEnum>();

    [Fact]
    public void LongEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [LongEnumAttribute(LongEnum.None)]
            public class Foo { }
            """;

        Successful(LongEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_LongEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(LongEnum.None)]
            public class Foo { }
            """;

        Successful(LongEnum.None, source);
    }

    private IArgumentPatternMatchResult<LongEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private void Successful(LongEnum matchedArgument, string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<LongEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
