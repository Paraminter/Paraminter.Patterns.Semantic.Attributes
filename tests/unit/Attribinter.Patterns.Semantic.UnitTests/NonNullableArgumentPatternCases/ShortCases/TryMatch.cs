namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ShortCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void ShortAttribute_Successful()
    {
        var source = """
            [Attribinter.Short(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Short_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject((short)1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject(1)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void ObjectAttribute_String_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject("")]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    private ArgumentPatternMatchResult<short> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(short expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private void Unsuccessful(string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(argument);

        Assert.False(result.Successful);
    }
}
