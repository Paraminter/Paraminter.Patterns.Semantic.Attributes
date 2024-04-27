namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_ShortEnum
{
    [Fact]
    public void ShortEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.ShortEnumAttribute(Attribinter.ShortEnum.None)]
            public class Foo { }
            """;

        Successful(ShortEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ShortEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.ShortEnum.None)]
            public class Foo { }
            """;

        Successful(ShortEnum.None, source);
    }

    private ArgumentPatternMatchResult<ShortEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<ShortEnum> Fixture = PatternFixtureFactory.Create<ShortEnum>();

    [AssertionMethod]
    private void Successful(ShortEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
