namespace Attribinter.Patterns.Semantic.EnumArgumentPatternFactoryCases.EnumArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch_ByteEnum
{
    [Fact]
    public void ByteEnumAttribute_Successful()
    {
        var source = """
            [Attribinter.ByteEnumAttribute(Attribinter.ByteEnum.None)]
            public class Foo { }
            """;

        Successful(ByteEnum.None, source);
    }

    [Fact]
    public void ObjectAttribute_ByteEnum_Successful()
    {
        var source = """
            [Attribinter.NullableObject(Attribinter.ByteEnum.None)]
            public class Foo { }
            """;

        Successful(ByteEnum.None, source);
    }

    private ArgumentPatternMatchResult<ByteEnum> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture<ByteEnum> Fixture = PatternFixtureFactory.Create<ByteEnum>();

    [AssertionMethod]
    private void Successful(ByteEnum expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }
}
