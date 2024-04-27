namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_SByteEnum
{
    [Fact]
    public void SByteEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.SByteEnumAttribute(Attribinter.SByteEnum.None)]
            public class Foo { }
            """;

        Successful(SByteEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_SByteEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.SByteEnum.None)]
            public class Foo { }
            """;

        Successful(SByteEnum.None, source);
    }

    private ArgumentPatternMatchResult<SByteEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<SByteEnum> Fixture = PatternFixtureFactory.Create<SByteEnum>();

    [AssertionMethod]
    private void Successful(SByteEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
