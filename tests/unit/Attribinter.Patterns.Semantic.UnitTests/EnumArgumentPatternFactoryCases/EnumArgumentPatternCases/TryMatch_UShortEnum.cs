namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_UShortEnum
{
    [Fact]
    public void UShortEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.UShortEnumAttribute(Attribinter.UShortEnum.None)]
            public class Foo { }
            """;

        Successful(UShortEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_UShortEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.UShortEnum.None)]
            public class Foo { }
            """;

        Successful(UShortEnum.None, source);
    }

    private ArgumentPatternMatchResult<UShortEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<UShortEnum> Fixture = PatternFixtureFactory.Create<UShortEnum>();

    [AssertionMethod]
    private void Successful(UShortEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
