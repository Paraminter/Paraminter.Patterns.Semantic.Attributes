namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<bool> Target(IArgumentPattern<TypedConstant, bool> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext Context = PatternContext.Create();

    [Fact]
    public void Null_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(null)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Array_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject(new object[0])]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [Fact]
    public void Error_Unsuccessful()
    {
        var source = """
            [Attribinter.NullableObject((bool)42)]
            public class Foo { }
            """;

        Unsuccessful(source);
    }

    [AssertionMethod]
    private static void Unsuccessful(string source)
    {
        var argument = TypedConstantFactory.Create(source);

        var result = Target(Context.Pattern, argument);

        Assert.False(result.Successful);
    }
}
