namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_ULongEnum
{
    [Fact]
    public void ULongEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.ULongEnumAttribute(Attribinter.ULongEnum.None)]
            public class Foo { }
            """;

        Successful(ULongEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ULongEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.ULongEnum.None)]
            public class Foo { }
            """;

        Successful(ULongEnum.None, source);
    }

    private ArgumentPatternMatchResult<ULongEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<ULongEnum> Fixture = PatternFixtureFactory.Create<ULongEnum>();

    [AssertionMethod]
    private void Successful(ULongEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
