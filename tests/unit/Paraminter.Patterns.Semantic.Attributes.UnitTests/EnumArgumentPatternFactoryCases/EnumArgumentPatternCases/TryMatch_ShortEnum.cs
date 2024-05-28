namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_ShortEnum
{
    private readonly IPatternFixture<ShortEnum> Fixture = PatternFixtureFactory.Create<ShortEnum>();

    [Fact]
    public void ShortEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [ShortEnumAttribute(ShortEnum.None)]
            public class Foo { }
            """;

        Successful(ShortEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ShortEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(ShortEnum.None)]
            public class Foo { }
            """;

        Successful(ShortEnum.None, source);
    }

    private IArgumentPatternMatchResult<ShortEnum> Target(
        TypedConstant argument)
    {
        return Fixture.Sut.TryMatch(argument);
    }

    [AssertionMethod]
    private void Successful(
        ShortEnum matchedArgument,
        string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<ShortEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
