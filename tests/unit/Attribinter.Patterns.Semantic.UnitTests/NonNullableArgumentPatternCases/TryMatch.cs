namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
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

    private static ArgumentPatternMatchResult<TOut> Target<TOut>(IPatternFixture<TOut> fixture, TypedConstant argument) => fixture.Sut.TryMatch(argument);

    [AssertionMethod]
    private static void Unsuccessful(string source)
    {
        var sut = ((IBoolArgumentPatternFactory)new BoolArgumentPatternFactory()).Create();

        var fixture = PatternFixtureFactory.Create(sut);

        var argument = TypedConstantFactory.Create(source);

        var result = Target(fixture, argument);

        Assert.False(result.Successful);
    }
}
