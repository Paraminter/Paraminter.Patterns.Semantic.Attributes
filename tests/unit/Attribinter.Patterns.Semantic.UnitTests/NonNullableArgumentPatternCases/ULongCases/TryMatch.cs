namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.ULongCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void ULongAttribute_Successful()
    {
        var source = """
            [Attribinter.ULong(1)]
            public class Foo { }
            """;

        Successful(1, source);
    }

    [Fact]
    public void ObjectAttribute_ULong_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject((ulong)1)]
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

    private ArgumentPatternMatchResult<ulong> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(ulong expected, string source)
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
