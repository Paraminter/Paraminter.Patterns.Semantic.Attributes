namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.BoolCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
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

    private ArgumentPatternMatchResult<bool> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(bool expected, string source)
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
