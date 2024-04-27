namespace Attribinter.Patterns.Semantic.NonNullableArgumentPatternCases.DoubleCases;

using Microsoft.CodeAnalysis;

using Xunit;

public sealed class TryMatch
{
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

    private ArgumentPatternMatchResult<double> Target(TypedConstant argument) => Fixture.Sut.TryMatch(argument);

    private readonly IPatternFixture Fixture = PatternFixtureFactory.Create();

    [AssertionMethod]
    private void Successful(double expected, string source)
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
