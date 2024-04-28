namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_LongEnum
{
    [Fact]
    public void LongEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.LongEnumAttribute(Attribinter.LongEnum.None)]
            public class Foo { }
            """;

        Successful(LongEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_LongEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.LongEnum.None)]
            public class Foo { }
            """;

        Successful(LongEnum.None, source);
    }

    private ArgumentPatternMatchResult<LongEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<LongEnum> Fixture = PatternFixtureFactory.Create<LongEnum>();

    [AssertionMethod]
    private void Successful(LongEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
