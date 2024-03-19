namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.IntCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<int> Target(IArgumentPattern<TypedConstant, int> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext Context = PatternContext.Create();

    [Fact]
    public void IntAttribute_Successful()
    {
        var source = """
            [Attribinter.Int(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Int_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_Short_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject((short)1)]
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
    private static void Successful(int expected, string source)
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
