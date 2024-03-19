namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.CharCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<char> Target(IArgumentPattern<TypedConstant, char> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext Context = PatternContext.Create();

    [Fact]
    public void CharAttribute_Char_Successful()
    {
        var source = """
            [Attribinter.Char((char)1)]
            public class Foo { }
            """;

        Successful((char)1, source);
    }

    [Fact]
    public void ObjectAttribute_Char_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject((char)1)]
            public class Foo { }
            """;

        Successful((char)1, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject(42)]
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

    [AssertionMethod]
    private static void Successful(char expected, string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.Equal(expected, result.GetMatchedArgument());
    }

    [AssertionMethod]
    private static void Unsuccessful(string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.False(result.Successful);
    }
}
