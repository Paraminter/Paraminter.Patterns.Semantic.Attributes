namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_IntEnum
{
    [Fact]
    public void IntEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.IntEnumAttribute(Attribinter.IntEnum.None)]
            public class Foo { }
            """;

        Successful(IntEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_IntEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.IntEnum.None)]
            public class Foo { }
            """;

        Successful(IntEnum.None, source);
    }

    private ArgumentPatternMatchResult<IntEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<IntEnum> Fixture = PatternFixtureFactory.Create<IntEnum>();

    [AssertionMethod]
    private void Successful(IntEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
