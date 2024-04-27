namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_UIntEnum
{
    [Fact]
    public void UIntEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.UIntEnumAttribute(Attribinter.UIntEnum.None)]
            public class Foo { }
            """;

        Successful(UIntEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_UIntEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.UIntEnum.None)]
            public class Foo { }
            """;

        Successful(UIntEnum.None, source);
    }

    private ArgumentPatternMatchResult<UIntEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<UIntEnum> Fixture = PatternFixtureFactory.Create<UIntEnum>();

    [AssertionMethod]
    private void Successful(UIntEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
