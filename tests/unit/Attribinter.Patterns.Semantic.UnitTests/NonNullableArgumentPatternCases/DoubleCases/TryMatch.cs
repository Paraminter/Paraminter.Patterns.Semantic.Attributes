namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.DoubleCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    private static ArgumentPatternMatchResult<double> Target(IArgumentPattern<TypedConstant, double> pattern, TypedConstant argument) => pattern.TryMatch(argument);

    private static readonly PatternContext Context = PatternContext.Create();

    [Fact]
    public void DoubleAttribute_Successful()
    {
        var source = """
            [Attribinter.Double(3.14)]
            public class Foo { }
            """;

        Successful(3.14, source);
    }

    [Fact]
    public void ObjectAttribute_Double_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(3.14)]
            public class Foo { }
            """;

        Successful(3.14, source);
    }

    [Fact]
    public void ObjectAttribute_Float_Unsuccessful()
    {
        var source = """
            [Attribinter.NonNullableObject(3.14f)]
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
    private static void Successful(double expected, string source)
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
