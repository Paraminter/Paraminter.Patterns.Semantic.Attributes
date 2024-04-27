namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.FloatCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
    [Fact]
    public void FloatAttribute_Successful()
    {
        var source = """
            [Attribinter.Float(3.14f)]
            public class Foo { }
            """;

        Successful(3.14f, source);
    }

    [Fact]
    public void ObjectAttribute_Float_Successful()
    {
        var source = """
            [Attribinter.NonNullableObject(3.14f)]
            public class Foo { }
            """;

        Successful(3.14f, source);
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

    private ArgumentPatternMatchResult<float> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(float expected, string source)
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
