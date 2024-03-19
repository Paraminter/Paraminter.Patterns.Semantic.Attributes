namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.BoolCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<bool> Target(IArgumentPattern<TypedConstant, bool> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext Context = PatternContext.Create();

    [Fact]
    public void BoolAttribute_True_Successful()
    {
        var source = """
            [Attribinter.Bool(true)]
            public class Foo { }
            """;

        Successful(true, source);
    }

    [Fact]
    public void BoolAttribute_False_Successful()
    {
        var source = """
            [Attribinter.Bool(false)]
            public class Foo { }
            """;

        Successful(false, source);
    }

    [Fact]
    public void ObjectAttribute_True_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(true)]
            public class Foo { }
            """;

        Successful(true, source);
    }

    [Fact]
    public void ObjectAttribute_False_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(false)]
            public class Foo { }
            """;

        Successful(false, source);
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
    private static void Successful(bool expected, string source)
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
