namespace Paraminter.Patterns.Semantic.Attributes.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Moq;

using Xunit;

public sealed class TryMatch_IntEnum
{
    private readonly IPatternFixture<IntEnum> Fixture = PatternFixtureFactory.Create<IntEnum>();

    [Fact]
    public void IntEnumAttribute_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [IntEnumAttribute(IntEnum.None)]
            public class Foo { }
            """;

        Successful(IntEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_IntEnum_Successful()
    {
        var source = """
            namespace Paraminter.Patterns.Semantic.Attributes;

            [NullableObject(IntEnum.None)]
            public class Foo { }
            """;

        Successful(IntEnum.None, source);
    }

    private IArgumentPatternMatchResult<IntEnum> Target(
        TypedConstant argument)
    {
        return Fixture.Sut.TryMatch(argument);
    }

    [AssertionMethod]
    private void Successful(
        IntEnum matchedArgument,
        string source)
    {
        var matchResult = Mock.Of<IArgumentPatternMatchResult<IntEnum>>();

        var argument = TypedConstantFactory.Create(source);

        Fixture.MatchResultFactoryProviderMock.Setup((provider) => provider.Successful.Create(matchedArgument)).Returns(matchResult);

        var result = Target(argument);

        Assert.Same(matchResult, result);
    }
}
